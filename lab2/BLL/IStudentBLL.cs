using lab2.Models;

namespace lab2.BLL
{
    public interface IStudentBLL
    {
        public Student GetById(int id);
        public Student Add(Student std);
        public List<Student> GetAll();
        public void DeleteById(int id);
        public void Update(Student student);




    }
}
