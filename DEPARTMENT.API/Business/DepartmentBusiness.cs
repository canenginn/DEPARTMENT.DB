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

        public IDataResult<List<DepartmentApiModel>> GetDepartment() {

            try
            {

                List<DepartmentApiModel> departmentApis = new  List<DepartmentApiModel>();
				var departments = context.Departments.Where(x => x.isDeleted == false).ToList();

                foreach (var item in departments)
                {
                    DepartmentApiModel department = new DepartmentApiModel
                    {
						id = item.id,
						name = item.name,
						code = item.code,
						isDeleted = item.isDeleted
					};

					departmentApis.Add(department);

				}
				return new DataResult<List<DepartmentApiModel>>(ResultStatus.Success, "Başarılı", departmentApis);
			}
			catch (Exception ex)
			{
				return new DataResult<List<DepartmentApiModel>>(ResultStatus.Error, ex.Message);
			}
		
          
        }
        public IDataResult<DepartmentApiModel> AddDepartment(DepartmentApiModel department)
        {
            try
            {
                Department newDepartment = new Department();
                if (newDepartment != null)
                {
                    newDepartment.name = department.name;
                    newDepartment.code = department.code;
                }
				context.Departments.Add(newDepartment);
				context.SaveChanges();
				return new DataResult<DepartmentApiModel>(ResultStatus.Success, "Başarılı", department);
			}
			catch (Exception ex)
			{
				return new DataResult<DepartmentApiModel>(ResultStatus.Error, ex.Message);
			}

		}
        public IDataResult<DepartmentApiModel> EditDepartment(DepartmentApiModel department)
        {
			try
			{
				Department updateDepartment = context.Departments.Where(x => x.id == department.id && x.isDeleted == false).FirstOrDefault();

				if (updateDepartment != null)
				{
					updateDepartment.name = department.name;
					updateDepartment.code = department.code;
				}
				context.Departments.UpdateRange(updateDepartment);
				context.SaveChanges();
				return new DataResult<DepartmentApiModel>(ResultStatus.Success, "Başarılı", department);
			}
			catch (Exception ex)
			{
				return new DataResult<DepartmentApiModel>(ResultStatus.Error, ex.Message);
			}
        }
        public IDataResult<DepartmentApiModel> DeleteDepartment(string id)
        {
			try
			{
				Department department = context.Departments.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
				if (department != null)
				{
					department.isDeleted = true;
					context.Departments.Update(department);
					context.SaveChanges();
					return new DataResult<DepartmentApiModel>(ResultStatus.Success, "Başarılı");
				}
				else
				{
					return new DataResult<DepartmentApiModel>(ResultStatus.Warning, "Null");
				}

			}
			catch (Exception ex)
			{
				return new DataResult<DepartmentApiModel>(ResultStatus.Warning, ex.Message);
			}


		}
    }
}
