namespace lab2.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        public string Crs_Name { get; set; }
        public int Crs_Duration { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
            = new HashSet<Department>();

        public virtual List<StudentCourse> CourseStudents { get; set; }
    }
}
