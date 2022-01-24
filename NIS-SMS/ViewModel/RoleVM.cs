using System.ComponentModel.DataAnnotations;

namespace NIS.ViewModel
{
    public class RoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
