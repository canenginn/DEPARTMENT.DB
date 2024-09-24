using DEPARTMENT.WEB.Business;
using DEPARTMENT.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace DEPARTMENT.WEB.Controllers
{
    public class UserController : Controller
    {
        UserBusiness userBusiness;
        public UserController()
        {
            userBusiness = new UserBusiness();
            
        }
        public IActionResult Index()
        {
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
