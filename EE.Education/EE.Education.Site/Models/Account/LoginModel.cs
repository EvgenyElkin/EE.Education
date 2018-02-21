using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EE.Education.Site.EF;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace EE.Education.Site.Models.Account
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PassHash { get; set; }
    }
}
