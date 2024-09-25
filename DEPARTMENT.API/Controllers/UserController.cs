using AutoMapper;
using DEPARTMENT.API.Business;
using DEPARTMENT.API.Models;
using DEPARTMENT.DB;
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
        public UserController()
        {
            business = new UserBusiness();
        }
        [AllowAnonymous]
        [HttpGet("GetUsers")]
        public IDataResult<List<UserApiModel>> GetUsers()
        {
            return business.GetUser();
        }
        [AllowAnonymous]
        [HttpPost("GetUserById")]
        public IDataResult<UserApiModel> GetUserById([FromBody] string id)
        {
            return business.GetUserById(id);
        }
        [AllowAnonymous]
        [HttpPost("AddUser")]
        public IDataResult<UserApiModel> AddUser([FromBody] UserApiModel user)
        {
            return business.AddUser(user);
        }
        [AllowAnonymous]
        [HttpPost("EditUser")]
        public IDataResult<UserApiModel> EditUser([FromBody] UserApiModel user)
        {
            return business.EditUser(user);
        }
        [AllowAnonymous]
        [HttpPost("DeleteUser")]
        public IDataResult<UserApiModel> DeleteUser([FromBody] string id)
        {
            return business.DeleteUser(id);
        }

    }
}
