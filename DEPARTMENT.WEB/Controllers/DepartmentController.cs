using DEPARTMENT.WEB.Business;
using DEPARTMENT.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEPARTMENT.WEB.Controllers
{
	public class DepartmentController : Controller
	{
		DepartmentBusiness departmentBusiness;
		public DepartmentController()
		{
			departmentBusiness = new DepartmentBusiness();

		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public JsonResult GetDepartments()
		{
			var data = departmentBusiness.GetDepartments();
			return Json(data);

		}
		public JsonResult AddDepartment(DepartmentWebModel model)
		{

			var data = departmentBusiness.AddDepartment(model);
			return Json(data);

		}
		public JsonResult UpdateDepartment(DepartmentWebModel model)
		{

			var data = departmentBusiness.UpdateDepartment(model);
			return Json(data);

		}

		public JsonResult DeleteDepartment(string id)
		{

			var data = departmentBusiness.DeleteDepartment(id);
			return Json(data);

		}
	}
}
