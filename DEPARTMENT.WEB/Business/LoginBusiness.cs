
using DEPARTMENT.WEB.Models;
using DEPARTMENT.WEB.Services;
using Newtonsoft.Json;

namespace DEPARTMENT.WEB.Business
{
    public class LoginBusiness
    {

        Service service;
        public LoginBusiness()
        {
            service = new Service();

        }

        public async Task<LoginModel> Login(LoginUser user)
        {
            if ((user.username == null || user.password == null) /*&& user.page != "Report"*/)
            {
                return null;

            }

            var token = service.Post(user, "", "Login/Login").ToString();
            LoginModel json = JsonConvert.DeserializeObject<LoginModel>(token);
            if (json != null)
            {
                if (json.token != null)
                {

                    return json;
                }
            }

            return null;

        }

    }


}
