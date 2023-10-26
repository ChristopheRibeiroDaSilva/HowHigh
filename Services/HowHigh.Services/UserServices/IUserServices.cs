using HowHigh.Models.Models;

namespace HowHighServices.UserServices
{
    public interface IUserServices
    {
        Task<bool> CreateUser(Users user);
        //Test
        Task<Users> GetUser(int id);
    }
}