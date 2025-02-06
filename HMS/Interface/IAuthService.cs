using HMS.DTO;
using HMS.Model;

namespace HMS.Interface
{
    public interface IAuthService
    {
        Task<User?> GetLoggedInUserAsync();
        Task RegisterUser(RegisterDTO registerViewModel,string Role);
        Task LogInUser(LogInDTO logInViewModel);
        Task LogOutUser();

        Task SendWelcomeEmailToUser(string email);


        // for users that are trying to register as a DOCTOR
    }
}
