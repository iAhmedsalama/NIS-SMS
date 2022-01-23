using System.ComponentModel.DataAnnotations.Schema;

namespace Day2.Models
{
    public class CrsResult
    {
        public int ID { get; set; }
        public int Degree { get; set; }

        //ForeignKey for Trainee_ID
        [ForeignKey("Trainee")]
        public int Trainee_ID { get; set; }
        public Student Trainee { get; set; }


        //ForeignKey for Course_ID
        [ForeignKey("Course")]
        public int CrsID { get; set; }
        public Course Course { get; set; }
    }
}
