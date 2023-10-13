using System.ComponentModel.DataAnnotations;
namespace lab2.Models
{
	public class Department
	{
		[Key]
		public int DeptId { get; set; }

		[Required]
		[StringLength(10)]
		public string DeptName { get; set; }
		public virtual ICollection<Student> Students { get; set; } = new HashSet<Student>();

		public virtual ICollection<Course> Courses { get; set; } = new HashSet<Course>();

		public virtual ICollection<Instructor> Instructors { get; set; } = new HashSet<Instructor>();
	}
}
