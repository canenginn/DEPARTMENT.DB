using DEPARTMENT.DB;
using DEPARTMENT.DB.Models;
using DEPARTMENT.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;


namespace DEPARTMENT.API.Business
{
    public class DepartmentBusiness
    {
        DepartmentContext context;
        public DepartmentBusiness() { 
            context = new DepartmentContext();
        }

        public List<Department> GetDepartment() {
            var departments = context.Departments.Where(x=>x.isDeleted==false).ToList();
            return departments;
        }
        public string AddDepartment(DepartmentApiModel department)
        {
            Department newDepartment = new Department();
            if (newDepartment != null)
            {
              
                newDepartment.name = department.name;
                newDepartment.code = department.code;

                context.Departments.Add(newDepartment);
                context.SaveChanges();
                return "Add is successfull";
            }
            else
            {
                return "Add is not successfull.";
            }


        }
        public string EditDepartment(DepartmentApiModel department)
        {
            Department updateDepartment = context.Departments.Where(x => x.id == department.id && x.isDeleted==false).FirstOrDefault();
            if (updateDepartment != null)
            {
                updateDepartment.name = department.name;
                updateDepartment.code = department.code;
                context.Departments.UpdateRange(updateDepartment);
                context.SaveChanges();
                return "Update is successful.";

            }
            return "Update is not successful.";

        }
        public string DeleteDepartment(string id)
        {
            Department department = context.Departments.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
            if (department != null)
            {
                department.isDeleted = true;
                context.Departments.Update(department);
                context.SaveChanges();
                return "Delete is successfull";
            }
            return "Delete is not successfull";


        }
    }
}
