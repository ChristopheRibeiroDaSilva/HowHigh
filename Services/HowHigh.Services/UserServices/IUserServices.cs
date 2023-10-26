using HowHigh.Models.Models;

namespace HowHighServices.UserServices
{
    public interface IUserServices
    {
        Task<Users?> Login(string userlogin, string userpassword);
        Task<bool> CreateUser(Users user);
        Task<bool> DeleteUser(long id);
        Task<Users?> UpdateUser(Users user);
        Task<Users?> GetUser(long id);
    }
}