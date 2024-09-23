using DEPARTMENT.DB;
using DEPARTMENT.DB.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DEPARTMENT.API.Business
{
    public class UserBusiness
    {
        DepartmentContext context;
        public UserBusiness() { 
            context = new DepartmentContext();
        }

        public List<User> GetUser() {
            var user = context.Users.ToList();
            return user;
        }
        public User AddUser(User user)
        {
            // User newUser = new User();
            //newUser.departmentId = user.departmentId;
            //newUser.name = user.name;
            //newUser.email = user.email;
            //newUser.password = user.password;
            //newUser.username = user.username;
            //newUser.id = user.id;
            //newUser.lastName = user.lastName;
            //newUser.isDeleted = user.isDeleted;
            //newUser.userTypeId = user.userTypeId;

            context.Users.Add(user);
            context.SaveChanges();
            return user;

        }
        public User EditUser(User user)
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
            }
            return updateUser;

        }
        public User DeleteUser(string id)
        {
            User user = context.Users.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
            if (user != null)
            {            
                context.Users.Remove(user);
                context.SaveChanges();
            }
            return user;

        }
    }
}
