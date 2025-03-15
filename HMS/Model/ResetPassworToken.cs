using System;

namespace HMS.Model
{
    public class ResetPasswordToken
    {
        public int Id { get; set; } // Primary Key
       
        public string Token { get; set; } // The reset token
        public DateTime Expiration { get; set; } // Expiry time for security



        public string UserGmail { get; set; }


    }
}
