using DEPARTMENT.API.Business;
using DEPARTMENT.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DEPARTMENT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        UserTypeBusiness business;
        public UserTypeController()
        {
            business = new UserTypeBusiness();
        }

        [AllowAnonymous]
        [HttpGet("GetUserTypes")]
        public IDataResult<List<UserTypeApiModel>> GetUserTypes()
        {
            return business.GetUserTypes();
        }

        [AllowAnonymous]
        [HttpPost("AddUserType")]
        public IDataResult<UserTypeApiModel> AddUserType([FromBody] UserTypeApiModel userType)
        {
            return business.AddUserType(userType);
        }
        [AllowAnonymous]
        [HttpPost("EditUserType")]
        public IDataResult<UserTypeApiModel> EditUserType([FromBody] UserTypeApiModel userType)
        {
            return business.EditUserType(userType);
        }
        [AllowAnonymous]
        [HttpPost("DeleteUserType")]
        public IDataResult<UserTypeApiModel> DeleteUserType([FromBody] string id)
        {
            return business.DeleteUserType(id);
        }
    }
}
