using HowHigh.Models.Models;
using HowHighServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace HowHigh.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userServices = null;

        public UsersController(IUserService userServices)
        {
            this._userServices = userServices;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<bool>> CreateUser(Users user)
        {
            bool response;
            try { 
                response = await _userServices.CreateUser(user);
                if(response)
                    return Ok(true);
                else
                    return Problem("User already exist.");
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<ActionResult<Users>> UpdateUser(Users user)
        {
            Users? updatedUser;
            try
            {
                updatedUser = await _userServices.UpdateUser(user);
                if (updatedUser != null)
                    return Ok(user);
                else
                    return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            bool response;
            try
            {
                response = await _userServices.DeleteUser(id);
                if (response)
                    return Ok(true);
                else
                    return NotFound("User not found.");
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }

        [HttpGet]
        [Route("GetUser")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            try
            {
                var user = await _userServices.GetUser(id);
                if (user == null)
                    return NotFound("User not found.");
                else
                    return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult<Users>> Login(string pseudo, string userpassword)
        {
            try
            {
                var user = await _userServices.Login(pseudo, userpassword);
                if(user == null)
                    return NotFound("User not found.");
                else
                    return Ok(user);
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }
    }
}
