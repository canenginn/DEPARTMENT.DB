using DEPARTMENT.WEB.Models;
using DEPARTMENT.WEB.Services;
using Newtonsoft.Json;

namespace UserType.WEB.Business
{
    public class UserTypeBusiness
    {
        Service service;
        public UserTypeBusiness()
        {
            service = new Service();

        }

        public ResultDataUserTypeWebModels GetUserTypes()
        {
            var message = "";
            var data = service.Get("", "UserType/GetUserTypes").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserTypeWebModels();
            }
            message = "0";
            ResultDataUserTypeWebModels result = JsonConvert.DeserializeObject<ResultDataUserTypeWebModels>(data);
            return result;
        }
        public ResultDataUserTypeWebModel AddUserType(UserTypeWebModel model)
        {
            var message = "";
            if (model.type == null)
            {
                message = "404";
                return new ResultDataUserTypeWebModel
                {
                    Data = model,
                    Message = message,
                    ResultStatus = Convert.ToInt32(ResultStatus.Info),
                    Exception = ""
                };
            }
            var data = service.Post(model, "", "UserType/AddUserType").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserTypeWebModel();
            }
            message = "0";
            ResultDataUserTypeWebModel result = JsonConvert.DeserializeObject<ResultDataUserTypeWebModel>(data);
            return result;
        }
        public ResultDataUserTypeWebModel UpdateUserType(UserTypeWebModel model)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (model.id == null)
            {

                message = "404";
                return new ResultDataUserTypeWebModel
                {
                    Data = model,
                    Message = message,
                    ResultStatus = Convert.ToInt32(ResultStatus.Info),
                    Exception = ""
                };
            }


            var data = service.Post(model, "", "UserType/EditUserType").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserTypeWebModel();
            }
            ResultDataUserTypeWebModel result = JsonConvert.DeserializeObject<ResultDataUserTypeWebModel>(data);
            return result;
        }
        public ResultDataUserTypeWebModel DeleteUserType(string id)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (id == null || id == "0")
            {

                message = "404";
                return new ResultDataUserTypeWebModel();
            }


            var data = service.Post(id, "", "UserType/DeleteUserType").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserTypeWebModel();
            }
            ResultDataUserTypeWebModel result = JsonConvert.DeserializeObject<ResultDataUserTypeWebModel>(data);
            return result;
        }
    }
}
