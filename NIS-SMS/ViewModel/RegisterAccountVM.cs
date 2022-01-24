using System.ComponentModel.DataAnnotations;

namespace NIS.ViewModel
{
    public class RegisterAccountVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password not matches")]
        public string ConfirmPassword { get; set; }

    }
}
