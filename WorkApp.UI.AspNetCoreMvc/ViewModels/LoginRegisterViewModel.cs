using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WorkApp.UI.AspNetCoreMvc.ViewModels
{
    public class LoginRegisterViewModel
    {
        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailFree", controller: "Account")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
