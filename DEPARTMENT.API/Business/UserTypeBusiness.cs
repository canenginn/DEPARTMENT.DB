using DEPARTMENT.API.Models;
using DEPARTMENT.DB.Models;
using DEPARTMENT.DB;

namespace DEPARTMENT.API.Business
{
    public class UserTypeBusiness
    {
        private readonly DepartmentContext context;
        public UserTypeBusiness()
        {
            context = new DepartmentContext();
        }

        public IDataResult<List<UserTypeApiModel>> GetUserTypes()
        {

            try
            {

                List<UserTypeApiModel> userTypeApis = new List<UserTypeApiModel>();
                var userTypes= context.UserTypes.Where(x => x.isDeleted == false).ToList();

                foreach (var item in userTypes)
                {
                    UserTypeApiModel userType = new UserTypeApiModel
                    {
                        id = item.id,
                        type = item.type,                 
                        isDeleted = item.isDeleted
                    };

                    userTypeApis.Add(userType);

                }
                return new DataResult<List<UserTypeApiModel>>(ResultStatus.Success, "Başarılı", userTypeApis);
            }
            catch (Exception ex)
            {
                return new DataResult<List<UserTypeApiModel>>(ResultStatus.Error, ex.Message);
            }


        }
        public IDataResult<UserTypeApiModel> AddUserType(UserTypeApiModel userType)
        {
            try
            {
                UserType newUserType = new UserType();
                if (newUserType != null)
                {
                    newUserType.type = userType.type;
                  
                }
                context.UserTypes.Add(newUserType);
                context.SaveChanges();
                return new DataResult<UserTypeApiModel>(ResultStatus.Success, "Başarılı", userType);
            }
            catch (Exception ex)
            {
                return new DataResult<UserTypeApiModel>(ResultStatus.Error, ex.Message);
            }

        }
        public IDataResult<UserTypeApiModel> EditUserType(UserTypeApiModel userType)
        {
            try
            {
                UserType updateUserType = context.UserTypes.Where(x => x.id == userType.id && x.isDeleted == false).FirstOrDefault();

                if (updateUserType != null)
                {
                    updateUserType.type = userType.type;
                   
                }
                context.UserTypes.UpdateRange(updateUserType);
                context.SaveChanges();
                return new DataResult<UserTypeApiModel>(ResultStatus.Success, "Başarılı", userType);
            }
            catch (Exception ex)
            {
                return new DataResult<UserTypeApiModel>(ResultStatus.Error, ex.Message);
            }
        }
        public IDataResult<UserTypeApiModel> DeleteUserType(string id)
        {
            try
            {
                UserType userType = context.UserTypes.Where(x => x.id == Convert.ToInt32(id) && x.isDeleted == false).FirstOrDefault();
                if (userType != null)
                {
                    userType.isDeleted = true;
                    context.UserTypes.Update(userType);
                    context.SaveChanges();
                    return new DataResult<UserTypeApiModel>(ResultStatus.Success, "Başarılı");
                }
                else
                {
                    return new DataResult<UserTypeApiModel>(ResultStatus.Warning, "Null");
                }

            }
            catch (Exception ex)
            {
                return new DataResult<UserTypeApiModel>(ResultStatus.Warning, ex.Message);
            }


        }
    }
}
