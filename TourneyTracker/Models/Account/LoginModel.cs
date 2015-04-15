using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TourneyTracker.Models.Account
{
    public class LoginModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Vul een geldig e-mailadres in.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public bool IsPersistent { get; set; }
    }
}