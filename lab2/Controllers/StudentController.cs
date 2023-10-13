using lab2.BLL;
using lab2.Data;
using lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab2.Controllers
{
	public class StudentController : Controller
	{
		IStudentBLL studentBLL;
        IDepartmentBll departmentBLL ;

		public StudentController(IStudentBLL std,IDepartmentBll _departmentBll)
		{
			studentBLL = std;
			departmentBLL = _departmentBll;
		}
		public IActionResult Index()
		{
			var st = studentBLL.GetAll();
			return View(st);
		}
        public IActionResult Details(int? id)

		{

			if (id == null)
				return BadRequest();
			var student = studentBLL.GetById(id.Value);
			if (student == null)
				return NotFound();

			return View(student);
		}

		public IActionResult Create() {
			var depts = departmentBLL.GetAll();
			ViewBag.depts =new SelectList(depts, "DeptId", "DeptName");
			return View();
		}

		[HttpPost]
		public IActionResult Create(Student std)
		{
			if (ModelState.IsValid)
			{
				studentBLL.Add(std);
				return RedirectToAction("Index");
			}
			ViewBag.depts = new SelectList(departmentBLL.GetAll(), "DeptId", "DeptName");
			return View(std);
		}
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return BadRequest();
			//studentBLL.DeleteById(id.Value);
			var model = studentBLL.GetById(id.Value);
			if(model == null) return NotFound();
			return View(model);
        }
		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int? id)
		{
			studentBLL.DeleteById(id.Value);
			return RedirectToAction("index");
		}

        public IActionResult Edit(int? id)
		{
			if(id == null) return BadRequest();
			Student model =studentBLL.GetById(id.Value);
			if(model == null) return NotFound();
            ViewBag.depts = new SelectList(departmentBLL.GetAll(), "DeptId", "DeptName",model.FK_DeptID);
            return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Student model)
		{
			studentBLL.Update(model);
			return RedirectToAction("index");
		}
	}
}
