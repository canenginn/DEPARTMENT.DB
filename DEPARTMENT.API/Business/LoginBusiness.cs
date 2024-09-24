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
                        checkUser.Department = context.Departments.Where(x => x.id == checkUser.departmentId && x.isDeleted==false).FirstOrDefault();
                        checkUser.UserType = context.UserTypes.Where(x => x.id == checkUser.userTypeId && x.isDeleted == false).FirstOrDefault();
                        string jwt = jwtAuthenticationManager.Authenticate(checkUser);
                        ResponseLoginApiModel response = new ResponseLoginApiModel { id = checkUser.id, isDeleted = checkUser.isDeleted, username = checkUser.username, nameSurname = checkUser.name + " " + checkUser.lastName, departmentId = checkUser.departmentId,userTypeId=checkUser.userTypeId,email=checkUser.email, token = jwt  , Department = new DepartmentApiModel
                        {
                            id = checkUser.Department?.id ?? 0, // Assuming nullable check
                            name = checkUser.Department?.name,
                            code=checkUser.Department?.code,
                            isDeleted=checkUser.Department.isDeleted,

                        },
                            UserType = new UserTypeApiModel
                            {
                                id = checkUser.UserType?.id ?? 0, // Assuming nullable check
                                type = checkUser.UserType?.type,
                                isDeleted=checkUser.UserType.isDeleted
                            }
                        };
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
