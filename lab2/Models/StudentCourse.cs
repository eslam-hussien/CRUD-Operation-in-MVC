using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class StudentCourse
    {
        public int FK_StudentId { get; set; }
        public int FK_CourseId { get; set; }

        public int? Degree { get; set; }


        [ForeignKey("FK_StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("FK_CourseId")]
        public virtual Course Course { get; set; }
    }
}
