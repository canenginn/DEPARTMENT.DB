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
    public class DepartmentController : ControllerBase
    {
        DepartmentBusiness business;
        public DepartmentController()
        {
            business = new DepartmentBusiness();
        }

        [AllowAnonymous]
        [HttpGet("GetDepartments")]
        public List<Department> GetDepartments()
        {
            return business.GetDepartment();
        }

        [AllowAnonymous]
        [HttpPost("AddDepartment")]
        public string AddDepartment([FromBody] DepartmentApiModel department)
        {
            return business.AddDepartment(department);
        }
        [AllowAnonymous]
        [HttpPost("EditDepartment")]
        public string EditDepartment([FromBody] DepartmentApiModel department)
        {
            return business.EditDepartment(department);
        }
        [AllowAnonymous]
        [HttpPost("DeleteDepartment")]
        public string DeleteDepartment([FromBody] string id)
        {
            return business.DeleteDepartment(id);
        }
    }
}
