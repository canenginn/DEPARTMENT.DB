using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.WEB.Models
{
    public partial class DepartmentWebModel
    {
        public int id { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public bool isDeleted { get; set; }
    }
	public class ResultDataDepartmentWebModel
	{
		public DepartmentWebModel Data { get; set; }
		public int ResultStatus { get; set; }
		public string Message { get; set; }
		public object Exception { get; set; }
	}
	public class ResultDataDepartmentWebModels
	{
		public List<DepartmentWebModel> Data { get; set; }
		public int ResultStatus { get; set; }
		public string Message { get; set; }
		public object Exception { get; set; }
	}
}
