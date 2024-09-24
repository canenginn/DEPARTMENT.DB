using DEPARTMENT.WEB.Business;
using DEPARTMENT.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DEPARTMENT.WEB.Controllers
{
    public class UserController : Controller
    {
        UserBusiness userBusiness;
        DepartmentBusiness departmentBusiness;
        public UserController()
        {
            userBusiness = new UserBusiness();
            departmentBusiness = new DepartmentBusiness();
            
        }
        public IActionResult Index()
        {
            List<DepartmentWebModel> departments = departmentBusiness.GetDepartments().Data;
            ViewData["departments"] = departments;
            //List<UserTypeWebModel> userTypes = userBusiness.GetUserTypes().Data;
            //ViewData["userTypes"] = userTypes;
            return View();
        }
        [HttpGet]
        public JsonResult GetUsers()
        {
            var data = userBusiness.GetUsers();
            return Json(data);
         
        }
        public JsonResult AddUser(UserWebModel model)
        {

            var data = userBusiness.AddUser(model);
            return Json(data);

        }
        public JsonResult UpdateUser(UserWebModel model)
        {

            var data = userBusiness.UpdateUser(model);
            return Json(data);

        }

        public JsonResult DeleteUser(string id)
        {

            var data = userBusiness.DeleteUser(id);
            return Json(data);

        }
    }
}
