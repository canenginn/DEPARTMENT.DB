using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.DB.Models
{
    public partial class DepartmentApiModel
    {
        public int id { get; set; }   
        public string? name { get; set; }
        public string? code { get; set; }
        public bool isDeleted { get; set; }


    }
}
