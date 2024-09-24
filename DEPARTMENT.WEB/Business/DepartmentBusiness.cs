using DEPARTMENT.WEB.Models;
using DEPARTMENT.WEB.Services;
using Newtonsoft.Json;

namespace DEPARTMENT.WEB.Business
{
    public class DepartmentBusiness
    {

        Service service;
        public DepartmentBusiness()
        {
            service = new Service();

        }

        public ResultDataDepartmentWebModels GetDepartments()
        {
            var message = "";
            var data = service.Get("", "Department/GetDepartments").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataDepartmentWebModels();
            }
            message = "0";
			ResultDataDepartmentWebModels result = JsonConvert.DeserializeObject<ResultDataDepartmentWebModels>(data);
            return result;
        }
        public ResultDataDepartmentWebModel AddDepartment(DepartmentWebModel model)
        {
            var message = "";
            if (model.name == null )
            {
                message = "404";
                return new ResultDataDepartmentWebModel
				{
                    Data = model,
                    Message = message,
                    ResultStatus = Convert.ToInt32(ResultStatus.Info),
                    Exception = ""
                };
            }
            var data = service.Post(model, "", "Department/AddDepartment").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataDepartmentWebModel();
            }
			message = "0";
			ResultDataDepartmentWebModel result = JsonConvert.DeserializeObject<ResultDataDepartmentWebModel>(data);
            return result;
        }
        public ResultDataDepartmentWebModel UpdateDepartment(DepartmentWebModel model)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (model.id == null)
            {

                message = "404";
				return new ResultDataDepartmentWebModel
				{
					Data = model,
					Message = message,
					ResultStatus = Convert.ToInt32(ResultStatus.Info),
					Exception = ""
				};
			}


            var data = service.Post(model, "", "Department/EditDepartment").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataDepartmentWebModel();
            }
			ResultDataDepartmentWebModel result = JsonConvert.DeserializeObject<ResultDataDepartmentWebModel>(data);
            return result;
        }
        public ResultDataDepartmentWebModel DeleteDepartment(string id)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (id == null || id == "0")
            {

                message = "404";
                return new ResultDataDepartmentWebModel();
            }


            var data = service.Post(id, "", "Department/DeleteDepartment").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataDepartmentWebModel();
            }
			ResultDataDepartmentWebModel result = JsonConvert.DeserializeObject<ResultDataDepartmentWebModel>(data);
            return result;
        }

    }
}
