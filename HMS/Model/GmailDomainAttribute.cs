using System.ComponentModel.DataAnnotations;

namespace HMS.Model
{
    public class GmailDomainAttribute : ValidationAttribute
    {
        public GmailDomainAttribute() : base("Email must end with '@gmail.com'")
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var email = value.ToString();
            return email.EndsWith("@gmail.com");
        }
    }
}
