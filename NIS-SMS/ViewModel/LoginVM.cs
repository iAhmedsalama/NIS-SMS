using System.ComponentModel.DataAnnotations;

namespace NIS.ViewModel
{
    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remmber me")]
        public bool isPresisite { get; set; }
    }
}
