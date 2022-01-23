using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    [ModelMetadataType(typeof(InstructorMetaData))]
    public partial class Instructor { }

    public class InstructorMetaData
    {
        public int ID { get; set; }

        #region Remote validation supports client side validation
        [Remote(action: "NameExists",controller: "Instructor",ErrorMessage ="Instructor Name Exists",AdditionalFields ="ID" )]
        #endregion

        [Display(Name = "Instructor Name")]
        [Required]
        [MaxLength(50)]
        [RegularExpression(pattern: "^[a-zA-Z]{3,}$", ErrorMessage = "Name must be a characters and more than 2 characters")]
        public string Name { get; set; }

        [Display(Name = "Profile image")]
        [Required]
        public string Image { get; set; }

        [Required]
        [Range(5000, 20000)]
        public int Salary { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "max characters is 50 letter")]
        #region Trying to custom address validation
        //[Address(new[] { "cairo", "alex", "menofia" }, ErrorMessage = "Address must contaions [cairo, alex, menofia]")] //passing array of strings
        #endregion

        [RegularExpression(pattern: "(cairo|alex|menofia)", ErrorMessage = "Address must contaions [cairo, alex, menofia] with no sapaces")]
        public string Address { get; set; }


        [ForeignKey("Department")]
        public int dept_id { get; set; }
        public Department Department { get; set; }


        [ForeignKey("Course")]
        public int CrsID { get; set; }
        public Course Course { get; set; }
    }
}
