using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIS.Models
{
    public partial class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int Degree { get; set; }

        //ForeignKey for dept_id
        [ForeignKey("Department")]

        public int dept_id { get; set; }
        public Department Department { get; set; }


        #region Add Composite Primary Key
        //public virtual ICollection<CrsResult> CrsResults { get; set; } = new HashSet<CrsResult>();
        #endregion

    }
}
