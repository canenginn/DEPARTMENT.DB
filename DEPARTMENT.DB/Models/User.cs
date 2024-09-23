using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.DB.Models
{
    public partial class User
    {
        public int id { get; set; }   
        public string? username { get; set; }
        public string password { get; set; }
        public string? name { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public bool isDeleted { get; set; } 
        public int departmentId { get; set; }
        public int userTypeId { get; set; }






    }
}
