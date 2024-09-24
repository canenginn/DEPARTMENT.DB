using DEPARTMENT.API.JwtToken;
using DEPARTMENT.API.Models;
using DEPARTMENT.DB;
using DEPARTMENT.DB.Models;
using Microsoft.AspNetCore.Authentication;

namespace DEPARTMENT.API.Business
{
    public class LoginBusiness
    {
        private readonly DepartmentContext context;
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;
        public LoginBusiness(IJwtAuthenticationManager jwtAuthentication)
        {
            this.jwtAuthenticationManager = jwtAuthentication;
            context = new DepartmentContext();
        }
        public ResponseLoginApiModel Login(RequestLoginApiModel login)
        {

            try
            {
                if (login.username != null || login.password != null)
                {

                    User checkUser = context.Users.Where(x => x.password == login.password && x.username == login.username).FirstOrDefault();
                    if (checkUser != null)
                    {
                        checkUser.password = null;
                        string jwt = jwtAuthenticationManager.Authenticate(checkUser);
                        ResponseLoginApiModel response = new ResponseLoginApiModel { id = checkUser.id, isDeleted = checkUser.isDeleted, username = checkUser.username, nameSurname = checkUser.name + " " + checkUser.lastName, departmentId = checkUser.departmentId,userTypeId=checkUser.userTypeId,email=checkUser.email, token = jwt };
                        return response;
                    }

                }
                return null;

            }
            catch (Exception ex)
            {

                return null;
            }

        }
    }
}
