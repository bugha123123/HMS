using HMS.DB;
using HMS.DTO;
using HMS.Interface;
using HMS.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Web;


namespace HMS.Service
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService emailService;
        private readonly AppDbContextion _db;

        public AuthService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager, SignInManager<User> signInManager, IEmailService emailService, AppDbContextion db)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _signInManager = signInManager;
            this.emailService = emailService;
            _db = db;
        }

        public async Task<User?> GetLoggedInUserAsync()
        {
            if (_httpContextAccessor.HttpContext.User.Identity?.IsAuthenticated != true)
            {
                return null;
            }

            // Get the user name
            string? userName = _httpContextAccessor.HttpContext.User.Identity?.Name;

            if (userName == null)
            {
                return null;
            }

            // Find the user by username
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return null;
            }

            // Include the Doctor model if the user is a doctor
            var doctor = await _db.Doctors
                .Where(d => d.UserId == user.Id) // Assuming UserId is a foreign key in Doctor model
                .FirstOrDefaultAsync();

            // If a Doctor exists for this user, assign it to the User object
            if (doctor != null)
            {
                user.Doctor = doctor; // Assuming you've added a Doctor navigation property in your User model
            }

            return user;
        }





        public async Task RegisterUser(RegisterDTO registerViewModel, string role)
        {
        
            // Create the new user object and map the properties
            var user = new User
            {
                
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email,
               Gender = registerViewModel.Gender,
               Age = registerViewModel.Age
               
            };

            // Create the user
            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!result.Succeeded)
            {
                return;
            }

     
            // Add user to the role (Doctor, User, Admin, etc.)
            await _userManager.AddToRoleAsync(user, role);

            // Sign the user in
            await _signInManager.SignInAsync(user, isPersistent: false);

            // Send the welcome email
            await SendWelcomeEmailToUser(registerViewModel.Email);

        }

     




        public async Task LogInUser(LogInDTO logInViewModel)
        {
            if (logInViewModel == null)
            {
                throw new ArgumentNullException(nameof(logInViewModel), "LogInViewModel cannot be null");
            }

            // Attempt to sign in the user using their email and password
            var result = await _signInManager.PasswordSignInAsync(logInViewModel.Email, logInViewModel.Password, false, lockoutOnFailure: false);
        }

        public async Task LogOutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task SendWelcomeEmailToUser(string email)
        {
            var htmlBody = $@"
<html>
<head>
    <style>
        .email-container {{
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            color: #333;
            padding: 20px;
            border-radius: 10px;
            text-align: center;
            max-width: 600px;
            margin: 0 auto;
        }}
        .header {{
            background-color: #6b46c1;
            color: #fff;
            padding: 15px;
            border-radius: 10px;
            margin-bottom: 20px;
        }}
        .button {{
            display: inline-block;
            background-color: #6b46c1;
            color: black;
            padding: 10px 20px;
            border-radius: 5px;
            text-decoration: none;
            font-weight: bold;
            margin-top: 20px;
            transition: background-color 0.3s;
        }}
        .button:hover {{
            background-color: #805ad5;
        }}
        .footer {{
            font-size: 0.9em;
            color: #b3b3b3;
            margin-top: 30px;
        }}
    </style>
</head>
<body>
    <div class='email-container'>
        <div class='header'>
            <h2>Welcome to HMS!</h2>
        </div>
        <p>Hi there!</p>
        <p>We're excited to have you as a new member of the HMS  community! Get ready to dive into the world of movies</p>
        <p>To get started, click the button below and explore our latest arrivals and special offers:</p>
        <a href='https://localhost:7194/Home/Index' class='button'>Start Booking</a>
        <p class='footer'>If you have any questions or need help, feel free to reach out to our support team.</p>
    </div>
</body>
</html>
";

            await emailService.SendEmailAsync(email, "Welcome to HMS!", htmlBody);
        }
        public async Task SendForgetPasswordEmail(string gmail)
        {
            if (string.IsNullOrWhiteSpace(gmail))
                throw new ArgumentException("Email cannot be null or empty", nameof(gmail));

            var user = await _userManager.FindByEmailAsync(gmail);
            if (user == null)
                throw new InvalidOperationException("User not found");

            // Generate the reset password token
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            // Create the reset password link (Do not encode the token here, store raw)
            var resetPasswordLink = $"https://localhost:7253/Auth/resetpassword?email={HttpUtility.UrlEncode(gmail)}&token={resetToken}";

            string body = $@"
        <p>Hello,</p>
        <p>You requested to reset your password. Click the link below:</p>
        <p><a href='{resetPasswordLink}'>Reset Password</a></p>
        <p>If you did not request this, please ignore this email.</p>
        <p>Best regards,<br>HMS</p>
    ";

            // Store the token in the DB (store raw token)
            var tokenEntry = new ResetPasswordToken
            {
                UserGmail = gmail,
                Token = resetToken,  
                Expiration = DateTime.UtcNow.AddMinutes(30)  // Set expiration
            };

            await _db.ResetPasswordTokens.AddAsync(tokenEntry);
            await _db.SaveChangesAsync();

            // Send the email
            await emailService.SendEmailAsync(gmail, "Reset Password", body);
        }




        public async Task ResetPassword(string gmail, string newPassword, string confirmNewPassword, string token)
        {
            
            if (string.IsNullOrWhiteSpace(gmail) || string.IsNullOrWhiteSpace(token))
                throw new ArgumentException("Invalid email or token");

            if (newPassword != confirmNewPassword)
                throw new InvalidOperationException("Passwords do not match");

            var user = await _userManager.FindByEmailAsync(gmail);
            if (user == null)
                throw new InvalidOperationException("User not found");

            // Decode the token from the URL (in case it was URL-encoded)
            

            // Get the token entry from the DB (raw token stored here)
            var tokenEntry = await _db.ResetPasswordTokens
                .FirstOrDefaultAsync(t => t.UserGmail.ToLower() == gmail.ToLower().Trim());

            if (tokenEntry == null || tokenEntry.Expiration < DateTime.UtcNow)
                throw new InvalidOperationException("Reset request expired or not found");

            // Compare the decoded token with the one stored in the DB
            if (tokenEntry.Token.Trim() != tokenEntry.Token.Trim())
                throw new InvalidOperationException("Invalid token");

            // Use the raw token directly (no need for decoding)
            var hashedPassword = _userManager.PasswordHasher.HashPassword(user, newPassword);
            user.PasswordHash = hashedPassword;

            // Save the changes to the user
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                throw new InvalidOperationException($"Password reset failed. Reason(s): {errors}");
            }

            // Step 4: Remove the token from the database after successful password reset
            _db.ResetPasswordTokens.Remove(tokenEntry);
            await _db.SaveChangesAsync();
        }




    }
}



