using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIS.Models
{
    [ModelMetadataType(typeof(StudentMetaData))]
    public partial class Student { }

    public class StudentMetaData
    {
        public int ID { get; set; }

        #region Remote validation supports client side validation
        [Remote(action: "NameExists", controller: "Student", ErrorMessage = "name already exist",
            AdditionalFields = "ID")]//additional field to pass -> id of specific student when edit it
        #endregion

        [Display(Name = "Student Name")]
        [Required]
        [MaxLength(50)]
        [RegularExpression(pattern: "^[a-zA-Z]{3,}$", ErrorMessage = "Name must be a characters and more than 2 characters")]
        public string Name { get; set; }

        [Display(Name = "Profile image")]
        [Required]
        //[RegularExpression(@"\w+\.(jpg | png)", ErrorMessage ="only valid format is (.jpg or .png)")]
        public string Image { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "max characters is 50 letter")]
        public string Address { get; set; }

        [Required]
        [Range(0, 100)]//built in validation

        #region Custom degree Validation
        [Degree(DegreeInfo = 50)]
        #endregion
        public int Degree { get; set; }

        //ForeignKey for dept_id
        [ForeignKey("Department")]

        public int dept_id { get; set; }
        public Department Department { get; set; }
    }
}
