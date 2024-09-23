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
        private readonly IMapper _mapper;
        public UserBusiness() { 
            context = new DepartmentContext();
        }

        public List<User> GetUser() {
            var user = context.Users.Where(x => x.isDeleted == false).Include(x => x.Department).Include(x => x.UserType).ToList();
            return user;

        }
        public string AddUser(UserApiModel user)
        {
            User newUser = new User();
            if (user != null)
            {
                newUser.departmentId = user.departmentId;
                newUser.name = user.name;
                newUser.email = user.email;
                newUser.password = user.password;
                newUser.username = user.username;
                newUser.lastName = user.lastName;
                newUser.isDeleted = user.isDeleted;
                newUser.userTypeId = user.userTypeId;

                context.Users.Add(newUser);
                context.SaveChanges();
                return "Add is successfull";
            }
            else
            {
                return "Add is not successfull.";
            }


        }
        public string EditUser(UserApiModel user)
        {
            User updateUser = context.Users.Where(x => x.id == user.id && x.isDeleted==false).FirstOrDefault();
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

                context.Users.UpdateRange(updateUser);
                context.SaveChanges();
                return "Update is successful.";

            }
            return "Update is not successful.";

        }
        public string DeleteUser(string id)
        {
            User user = context.Users.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
            if (user != null)
            {
                user.isDeleted = true;
                context.Users.Update(user);
                context.SaveChanges();
                return "Delete is successfull";
            }
            return "Delete is not successfull";


        }
    }
}
