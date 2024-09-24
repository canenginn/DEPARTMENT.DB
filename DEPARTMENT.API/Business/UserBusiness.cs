using DEPARTMENT.DB;
using DEPARTMENT.DB.Models;
using DEPARTMENT.API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using AutoMapper;
using Microsoft.EntityFrameworkCore;


namespace DEPARTMENT.API.Business
{
    public class UserBusiness
    {
        private readonly DepartmentContext context;

        public UserBusiness()
        {
            context = new DepartmentContext();

        }
        public IDataResult<List<UserApiModel>> GetUser()
        {
            List<UserApiModel> userApis = new List<UserApiModel>();
            try
            {
                var users = context.Users.Where(x => x.isDeleted == false)
                                         .Include(x => x.Department)
                                         .Include(x => x.UserType)
                                         .ToList();

                foreach (var item in users)
                {
                    UserApiModel userApi = new UserApiModel
                    {
                        id = item.id,
                        name = item.name,
                        lastName = item.lastName,
                        username = item.username,
                        email = item.email,
                        password = item.password,
                        departmentId = item.departmentId,
                        userTypeId = item.userTypeId
                    };

                    if (item.UserType != null)
                    {
                        userApi.UserType = new UserTypeApiModel
                        {
                            id = item.UserType.id,
                            type = item.UserType.type,
                            isDeleted = item.UserType.isDeleted
                        };
                    }

                    if (item.Department != null)
                    {
                        userApi.Department = new DepartmentApiModel
                        {
                            id = item.Department.id,
                            name = item.Department.name,
                            code = item.Department.code,
                            isDeleted = item.Department.isDeleted
                        };
                    }

                    userApis.Add(userApi);
                }

                return new DataResult<List<UserApiModel>>(ResultStatus.Success, "Başarılı", userApis);
            }
            catch (Exception ex)
            {
                return new DataResult<List<UserApiModel>>(ResultStatus.Error, ex.Message);
            }
        }
        public IDataResult<UserApiModel> AddUser(UserApiModel user)
        {

            try
            {

                User newUser = new User();
                newUser.departmentId = user.departmentId;
                newUser.name = user.name;
                newUser.email = user.email;
                newUser.password = user.password;

                newUser.username = user.username;
                newUser.lastName = user.lastName;
                newUser.isDeleted = user.isDeleted;
                newUser.userTypeId = user.userTypeId;
                if (newUser.Department != null)
                {
                    newUser.Department.id = user.Department.id;
                    newUser.Department.name = user.Department.name;
                    newUser.Department.code = user.Department.code;
                    newUser.Department.isDeleted = user.Department.isDeleted;
                }
                if (newUser.UserType != null)
                {
                    newUser.UserType.id = user.UserType.id;
                    newUser.UserType.type = user.UserType.type;
                    newUser.UserType.isDeleted = user.UserType.isDeleted;
                }

                context.Users.Add(newUser);
                context.SaveChanges();

                return new DataResult<UserApiModel>(ResultStatus.Success, "Başarılı", user);
            }
            catch (Exception ex)
            {
                return new DataResult<UserApiModel>(ResultStatus.Error, ex.Message);
            }
        }
        public IDataResult<UserApiModel> EditUser(UserApiModel user)
        {
            try
            {
                User updateUser = context.Users.Where(x => x.id == user.id && x.isDeleted == false).FirstOrDefault();
                if (updateUser != null)
                {
                    updateUser.departmentId = user.departmentId;
                    updateUser.name = user.name;
                    updateUser.email = user.email;
                    updateUser.password = user.password;
                    updateUser.username = user.username;
                    updateUser.id = user.id;
                    updateUser.lastName = user.lastName;
                    updateUser.isDeleted = user.isDeleted;
                    updateUser.userTypeId = user.userTypeId;
                    if (updateUser.Department != null)
                    {
                        updateUser.Department.id = user.Department.id;
                        updateUser.Department.name = user.Department.name;
                        updateUser.Department.code = user.Department.code;
                        updateUser.Department.isDeleted = user.Department.isDeleted;
                    }
                    if (updateUser.UserType != null)
                    {
                        updateUser.UserType.id = user.UserType.id;
                        updateUser.UserType.type = user.UserType.type;
                        updateUser.UserType.isDeleted = user.UserType.isDeleted;
                    }

                    context.Users.UpdateRange(updateUser);
                    context.SaveChanges();

                    return new DataResult<UserApiModel>(ResultStatus.Success, "Başarılı", user);

                }
                return new DataResult<UserApiModel>(ResultStatus.Warning, "Null", user);
            }
            catch (Exception ex)
            {
                return new DataResult<UserApiModel>(ResultStatus.Error, ex.Message);
            }


        }
        public IDataResult<UserApiModel> DeleteUser(string id)
        {
            try
            {
                User user = context.Users.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
                if (user != null)
                {
                    user.isDeleted = true;
                    context.Users.Update(user);
                    context.SaveChanges();
                    return new DataResult<UserApiModel>(ResultStatus.Success, "Başarılı");
                }
                else
                {
                    return new DataResult<UserApiModel>(ResultStatus.Warning, "Null");
                }
            }
            catch (Exception ex)
            {
                return new DataResult<UserApiModel>(ResultStatus.Warning, ex.Message);
            }
        }




    }
}
