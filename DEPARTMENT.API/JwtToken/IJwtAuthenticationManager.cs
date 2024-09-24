using DEPARTMENT.DB.Models;

namespace DEPARTMENT.API.JwtToken
{
    public interface IJwtAuthenticationManager
    {
       string Authenticate(User user);
        int Decode(string v);
    }
}
