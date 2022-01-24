using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NIS.Models
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Degree { get; set; }
        public int MinDegree { get; set; }


        [ForeignKey("Department")]
        public int dept_id { get; set; }
        public Department Department { get; set; }

        //public virtual ICollection<Trainee> Trainee { get; set; } = new HashSet<Trainee>();
        #region Add Composite Primary Key
        //public virtual ICollection<CrsResult> CrsResults { get; set; } = new HashSet<CrsResult>();
        #endregion

    }
}
