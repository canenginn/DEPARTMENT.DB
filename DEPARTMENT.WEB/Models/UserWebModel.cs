using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.WEB.Models
{
    public class UserWebModel
    {
        public int id { get; set; }
        public string? username { get; set; }
        public string password { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public bool isDeleted { get; set; }
        public int departmentId { get; set; }
        public DepartmentWebModel? Department { get; set; }
        public int userTypeId { get; set; }
		public UserTypeWebModel? UserType { get; set; }

	}
    public class ResultDataUserWebModel
    {
        public UserWebModel Data { get; set; }
        public int ResultStatus { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }
    }
    public class ResultDataUserWebModels
    {
        public List<UserWebModel> Data { get; set; }
        public int ResultStatus { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }
    }
}
