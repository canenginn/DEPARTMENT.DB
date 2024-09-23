using DEPARTMENT.API.Business;
using DEPARTMENT.API.Models;
using DEPARTMENT.DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEPARTMENT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
         UserBusiness business;
        public UserController() { 
            business = new UserBusiness();  
        }

        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public List<User> GetUsers()
        {
            return business.GetUser();
        }

        [AllowAnonymous]
        [HttpPost("AddUser")]
        public string AddUser([FromBody] UserApiModel user)
        {
            return business.AddUser(user);
        }
        [AllowAnonymous]
        [HttpPost("EditUser")]
        public string EditUser([FromBody] UserApiModel user)
        {
            return business.EditUser(user);
        }
        [AllowAnonymous]
        [HttpPost("DeleteUser")]
        public string DeleteUser([FromBody] string id)
        {
            return business.DeleteUser(id);
        }

    }
}
