
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

        public List<UserWebModel> GetUsers()
        {
            try
            {
                var data = service.Get("", "User/GetUsers").ToString();
                var json = JsonConvert.DeserializeObject<List<UserWebModel>>(data);

                return json;
            }
            catch
            {
                return null;
            }
        }

    }


}
