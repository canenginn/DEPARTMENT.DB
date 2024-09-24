using DEPARTMENT.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using UserType.WEB.Business;

namespace DEPARTMENT.WEB.Controllers
{
    public class UserTypeController : Controller
    {
        UserTypeBusiness UserTypeBusiness;
        public UserTypeController()
        {
            UserTypeBusiness = new UserTypeBusiness();

        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult GetUserTypes()
        {
            var data = UserTypeBusiness.GetUserTypes();
            return Json(data);

        }
        public JsonResult AddUserType(UserTypeWebModel model)
        {

            var data = UserTypeBusiness.AddUserType(model);
            return Json(data);

        }
        public JsonResult UpdateUserType(UserTypeWebModel model)
        {

            var data = UserTypeBusiness.UpdateUserType(model);
            return Json(data);

        }

        public JsonResult DeleteUserType(string id)
        {

            var data = UserTypeBusiness.DeleteUserType(id);
            return Json(data);

        }
    }
}
