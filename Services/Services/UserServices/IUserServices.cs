using HowHigh.Models.Models;

namespace Services.UserServices
{
    interface IUserServices
    {
        Task<bool> CreateUser(Users user);
    }
}