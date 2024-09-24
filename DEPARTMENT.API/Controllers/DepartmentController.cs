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
        public IDataResult<List<DepartmentApiModel>> GetDepartments()
        {
            return business.GetDepartment();
        }

        [AllowAnonymous]
        [HttpPost("AddDepartment")]
		public IDataResult<DepartmentApiModel> AddDepartment([FromBody] DepartmentApiModel department)
        {
            return business.AddDepartment(department);
        }
        [AllowAnonymous]
        [HttpPost("EditDepartment")]
        public IDataResult<DepartmentApiModel> EditDepartment([FromBody] DepartmentApiModel department)
        {
            return business.EditDepartment(department);
        }
        [AllowAnonymous]
        [HttpPost("DeleteDepartment")]
        public IDataResult<DepartmentApiModel> DeleteDepartment([FromBody] string id)
        {
            return business.DeleteDepartment(id);
        }
    }
}
