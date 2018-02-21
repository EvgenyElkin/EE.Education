using System.ComponentModel.DataAnnotations;

namespace EE.Education.Site.Models.Account
{
    public class RegistrationModel : LoginModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
    }
}