using HowHigh.Models.Models;
using HowHigh.Services.ThrowServices;
using HowHighServices.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace HowHigh.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ThrowController : ControllerBase
    {
        private readonly IThrowService _throwService = null;

        public ThrowController(IThrowService throwService)
        {
            this._throwService = throwService;
        }

        [HttpPost]
        [Route("CreateThrow")]
        public async Task<ActionResult<bool>> CreateThrow(ThrowHistories throw_History)
        {
            bool response;
            try
            {
                if (throw_History.high < 0)
                    return Problem("High can't be negative");
                response = await _throwService.CreateThrow(throw_History);
                if (response)
                    return Ok(true);
                else
                    return NotFound("Problem saving throw. User not found.");
            }
            catch (Exception ex)
            {
                return Problem("Problem saving throw , Sever Error : " + ex);
            }
        }
        
        [HttpGet]
        [Route("GetAllThrowHistories")]
        public async Task<ActionResult<List<ThrowHistories>>> GetAllThrowHistories()
        {
            try
            {
                var throw_Histories = await _throwService.GetAllThrowHistories();
                if (throw_Histories == null)
                    return NotFound("Throws not found.");
                else
                    return Ok(throw_Histories);
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }

        [HttpGet]
        [Route("GetThrowHistories")]
        public async Task<ActionResult<List<ThrowHistories>>> GetThrowHistories(int id_user)
        {
            try
            {
                var throw_Histories = await _throwService.GetThrowHistories(id_user);
                if (throw_Histories == null)
                    return NotFound("Problem retrieving throws, user not found.");
                else
                    return Ok(throw_Histories);
            }
            catch (Exception ex)
            {
                return Problem("Sever Error : " + ex);
            }
        }
    }
}
