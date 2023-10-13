using lab2.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace lab2.ViewModels
{
	public class EditDeptCoursesViewModel
	{
        public SelectList CourseInDept { get; set; }
        public SelectList CourseNotInDept { get; set; }
        public Department Department { get; set; }
    }
}
