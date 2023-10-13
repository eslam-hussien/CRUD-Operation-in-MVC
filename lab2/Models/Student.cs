using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lab2.Models
{
    public class Student
    {
		public Student()
		{
		}

		public Student(object value1, object value2)
		{
			Value1 = value1;
			Value2 = value2;
		}

		public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Age { get; set; }
        public int FK_DeptID { get; set; }

        [ForeignKey("FK_DeptID")]
        public virtual Department Department { get; set; }
        public virtual List<StudentCourse> StudentCourses { get; set; }
		public object Value1 { get; }
		public object Value2 { get; }
	}
}
