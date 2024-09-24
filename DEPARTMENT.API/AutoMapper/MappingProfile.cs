using AutoMapper;
using DEPARTMENT.API.Models;
using DEPARTMENT.DB.Models;

namespace DEPARTMENT.API.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<User, UserApiModel>();
			CreateMap<UserApiModel, User>();
            //CreateMap<List<User>, List<UserApiModel>>();
            //CreateMap<List<UserApiModel>, List<User>>();

            CreateMap<Department, DepartmentApiModel>();
			CreateMap<DepartmentApiModel, Department>();

			CreateMap<UserType, UserTypeApiModel>();
			CreateMap<UserTypeApiModel, UserType>();

		}
	}
}
