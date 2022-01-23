using Day2.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Day2
{
    //custom validation is server side only -> because unobtursive do not have this custom validation
    public class DegreeAttribute : ValidationAttribute
    {
        //pass value to DegreeAttribute
        public int DegreeInfo { get; set; } = 50;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Student student = validationContext.ObjectInstance as Student;
            
            int Degree = int.Parse(value.ToString());
            if (Degree > DegreeInfo)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Degree must be > 50");
        }
    }

    public class AddressAttribute : ValidationAttribute
    {
        #region pass array of strings

        private string[] vs;
        public AddressAttribute(string[] vs)
        {
            this.vs = vs;
        }

        #endregion

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Instructor instructor = validationContext.ObjectInstance as Instructor;

            var Address = value.ToString().ToLower().Trim();

            if (Address.Contains(Address))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("address must contain cairo, alex, menofia");

        }
    }
    
}
