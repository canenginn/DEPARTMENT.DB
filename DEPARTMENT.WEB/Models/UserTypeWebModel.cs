using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.WEB.Models
{
    public partial class UserTypeWebModel
    {
        public int id { get; set; }
        public string? type { get; set; }
        public bool isDeleted { get; set; }
    }
    public class ResultDataUserTypeWebModel
    {
        public UserTypeWebModel Data { get; set; }
        public int ResultStatus { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }
    }
    public class ResultDataUserTypeWebModels
    {
        public List<UserTypeWebModel> Data { get; set; }
        public int ResultStatus { get; set; }
        public string Message { get; set; }
        public object Exception { get; set; }
    }
}
