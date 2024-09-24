namespace DEPARTMENT.WEB.Models
{
    public class LoginModel
    {
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string nameSurname { get; set; }
    
        public bool isDeleted { get; set; }
        public int departmentId { get; set; }

		public int userTypeId { get; set; }
		//public UserType? UserType { get; set; }

		public string token { get; set; }
        public string email { get; set; }


    }
}
