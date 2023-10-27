using HowHigh.Models.Models;

namespace HowHighServices.UserServices
{
    public interface IUserService
    {
        Task<Users?> Login(string userlogin, string userpassword);
        Task<bool> CreateUser(Users user);
        Task<bool> DeleteUser(int id_user);
        Task<Users?> UpdateUser(Users user);
        Task<Users?> GetUser(int id_user);
    }
}