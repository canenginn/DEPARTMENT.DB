using DEPARTMENT.WEB.Models;
using DEPARTMENT.WEB.Services;
using Newtonsoft.Json;

namespace DEPARTMENT.WEB.Business
{
    public class UserBusiness
    {
        Service service;
        public UserBusiness()
        {
            service = new Service();
        }

        public ResultDataUserWebModels GetUsers()
        {

            var message = "";

            var data = service.Get("", "User/GetUsers").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserWebModels();
            }
            message = "0";
            ResultDataUserWebModels result = JsonConvert.DeserializeObject<ResultDataUserWebModels>(data);
            return result;
        }
        public ResultDataUserWebModel AddUser(UserWebModel model)
        {
            var message = "";

            if (model.username == null || model.password == null || model.name == null)
            {
                message = "404";
                return new ResultDataUserWebModel
                {
                    Data = model,
                    Message = message,
                    ResultStatus = Convert.ToInt32(ResultStatus.Info),
                    Exception = ""
                };
            }
            var data = service.Post(model, "", "User/AddUser").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserWebModel();
            }

            ResultDataUserWebModel result = JsonConvert.DeserializeObject<ResultDataUserWebModel>(data);
            return result;
        }
        public ResultDataUserWebModel UpdateUser(UserWebModel model)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (model.id == null)
            {

                message = "404";
                return new ResultDataUserWebModel();
            }


            var data = service.Post(model, "", "User/EditUser").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserWebModel();
            }
            ResultDataUserWebModel result = JsonConvert.DeserializeObject<ResultDataUserWebModel>(data);
            return result;
        }
        public ResultDataUserWebModel DeleteUser(string id)
        {
            var message = "";
            //zorunlu alanlar için kontrol edelim.
            if (id == null || id == "0")
            {

                message = "404";
                return new ResultDataUserWebModel();
            }


            var data = service.Post(id, "", "User/DeleteUser").ToString();
            if (data == null)
            {
                message = "400";
                return new ResultDataUserWebModel();
            }
            ResultDataUserWebModel result = JsonConvert.DeserializeObject<ResultDataUserWebModel>(data);
            return result;
        }


    }
}
