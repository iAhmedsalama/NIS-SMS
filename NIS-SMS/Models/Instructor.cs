using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public partial class Instructor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }


        [ForeignKey("Department")]
        public int dept_id { get; set; }
        public Department Department { get; set; }


        [ForeignKey("Course")]
        public int CrsID { get; set; }
        public Course Course { get; set; }
    }
}
