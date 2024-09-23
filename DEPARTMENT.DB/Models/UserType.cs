using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEPARTMENT.DB.Models
{
    public partial class UserType
    {
        public int id { get; set; }
        public string? type { get; set; }
        public bool isDeleted { get; set; }
    }
}
