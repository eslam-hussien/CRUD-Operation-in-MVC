using lab2.Models;

namespace lab2.BLL
{
	public interface IEntity<T> where T:class
	{ }

	public interface IDepartmentBll
	{
		public List<Department> GetAll();
		public Department GetById(int id);
		public void Update(Department department);
		public Department Add(Department dept);
		public void DeleteById(int id);

	}
}
