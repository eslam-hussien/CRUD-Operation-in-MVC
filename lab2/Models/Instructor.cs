namespace lab2.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Salary { get; set; }

        public int? FK_DeptNo { get; set; }

        public virtual Department Department { get; set; }
    }
}
