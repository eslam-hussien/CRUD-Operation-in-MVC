using lab2.BLL;
using lab2.Data;
using lab2.Models;
using lab2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace lab2.Controllers
{
	public class DepartmentController : Controller
	{
		IDepartmentBll departmentBLL;
        public DepartmentController(IDepartmentBll _departmentBll)
        {
            departmentBLL = _departmentBll;
        }
        StudentDb db;
		public IActionResult Index()

		{

			return View(departmentBLL.GetAll());
		}
		public IActionResult EditDeptCourses(int? id)
		{
			var allcourses =db.Courses.Include(a=>a.Departments).ToList();
			var department= db.Departments.Include(a=>a.Courses).FirstOrDefault(a=>a.DeptId == id.Value);
			var coursesindept = department.Courses;
			var coursesnot= allcourses.Except(coursesindept).ToList();
			//ViewBag.coursesindept = new SelectList(coursesindept, "CourseId", "Crs_Name");
			//ViewBag.coursesnotdept = new SelectList(coursesnot, "CourseId", "Crs_Name");
			//ViewBag.dept = department;
			EditDeptCoursesViewModel model = new EditDeptCoursesViewModel();
			model.CourseInDept = new SelectList(coursesindept, "CourseId", "Crs_Name");
			model.CourseNotInDept= new SelectList(coursesnot, "CourseId", "Crs_Name");
			model.Department= department;
			return View(model);
		}
		[HttpPost]
        public IActionResult EditDeptCourses(int? id,int []coursestoremove,int []couresetoadd)
			
		{
			Department dept= db.Departments.Include(a=>a.Courses).FirstOrDefault(a=>a.DeptId==id.Value);
            foreach (var item in coursestoremove)
            {
				var course = db.Courses.FirstOrDefault(a => a.CourseId == item);
				dept.Courses.Remove(course);
            }
            foreach (var item in couresetoadd)
            {
				var course = db.Courses.FirstOrDefault(a => a.CourseId == item);
				dept.Courses.Add(course);
			}
			db.SaveChanges();
            return RedirectToAction("Index");
		}

        public IActionResult Details(int? id)
		{
			return View();
		}
		public IActionResult Create()

		{
			return View();
		}
		public IActionResult Edit(int? id)
		{
			if (id == null) return BadRequest();
			var model = departmentBLL.GetById(id.Value);
			if (model == null) return NotFound();
			return View(model);
		}
		[HttpPost]
		public IActionResult Edit(Department model)
		{
			//model.DeptId =(int) Request.RouteValues["id"];
			departmentBLL.Update(model);
			return RedirectToAction("Index");
		}
	}
}
