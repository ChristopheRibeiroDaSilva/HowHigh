using HowHigh.Models.Models;
using HowHighServices.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowHigh.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices = null;

        public UsersController(IUserServices userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        public async Task<bool> CreateUser(Users user)
        {
            bool response;
            try { 
                response = await _userServices.CreateUser(user);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<Users> GetUser(int id)
        {
            try
            {
                var user = await _userServices.GetUser(id);
                return user;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
