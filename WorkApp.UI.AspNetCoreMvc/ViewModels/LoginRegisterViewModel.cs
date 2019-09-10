using System.ComponentModel.DataAnnotations;

namespace WorkApp.UI.AspNetCoreMvc.ViewModels
{
    /// <summary>
    /// Data transfer object that carries login and registration information from UI to the controller.
    /// </summary>
    public class LoginRegisterViewModel
    {
        /// <summary>
        /// Email adress of the user. Email must be unique in the database and it is required for login and registration.
        /// <para/>
        /// Attributes : 
        /// <see cref="RequiredAttribute"/>,
        /// <see cref="EmailAddressAttribute"/>
        /// </summary>
        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailFree", controller: "Account")]  // For remote validation (see Account/IsEmailFree action for details)
        public string Email { get; set; }

        /// <summary>
        /// Password of the user. Password complexity is set in the <see cref="Startup"/> class.
        /// <para/>
        /// Attributes : 
        /// <see cref="RequiredAttribute"/>,
        /// <see cref="DataTypeAttribute"/>
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
