using lab2.Data;
using lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace lab2.BLL
{
	public class StudentBLL:IStudentBLL
	{
		StudentDb db ;
        public StudentBLL(StudentDb _db)
        {
			db = _db; 
        }
        public Student GetById(int id)
		{
			return db.Students.Include(a=>a.Department).FirstOrDefault(a=>a.Id == id);
		}
		public Student Add(Student std) {
		db.Students.Add(std);
			db.SaveChanges();
			return std;
		}
		public List<Student> GetAll()
		{
            return db.Students.Include(a => a.Department).ToList();
        }
        public void DeleteById(int id)
        {
            var model = db.Students.FirstOrDefault(a => a.Id == id);
            if (model != null)
            {
                db.Students.Remove(model);
                db.SaveChanges();
            }
        }
		public void Update(Student student)
		{
			db.Update(student);
			db.SaveChanges();
		}
    }
}
