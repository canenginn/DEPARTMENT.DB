using Azure.Core;
using Azure;
using DEPARTMENT.API.Business;
using DEPARTMENT.API.JwtToken;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using DEPARTMENT.API.Models;

namespace DEPARTMENT.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public int userid;
        IJwtAuthenticationManager jwtAuthenticationManager;
        private IHttpContextAccessor accessor;
        LoginBusiness loginBusiness;
        public LoginController(IJwtAuthenticationManager jwtAuthenticationManager, IHttpContextAccessor accessor)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            loginBusiness = new LoginBusiness(jwtAuthenticationManager);
            userid = Convert.ToInt32(accessor?.HttpContext.User.FindFirstValue(ClaimTypes.SerialNumber));
            this.accessor = accessor;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public ResponseLoginApiModel Login(RequestLoginApiModel user)
        {
            return loginBusiness.Login(user);
        }
    }
}
