using lab2.Data;
using lab2.Models;

namespace lab2.BLL
{
	public class DepartmentBLL:IDepartmentBll
	{
		StudentDb db ;

        public DepartmentBLL(StudentDb _db)
        {
            db= _db;
        }
        public Department Add(Department dept)
		{
			throw new NotImplementedException();
		}

		public void DeleteById(int id)
		{
			throw new NotImplementedException();
		}

		public List<Department> GetAll()
		{
			return db.Departments.ToList();
		}
		public Department GetById(int id)
		{
			return db.Departments.FirstOrDefault(a => a.DeptId == id);

		}
		public void Update(Department department)
		{
			db.Departments.Update(department);
			db.SaveChanges();
		}
	}
}
