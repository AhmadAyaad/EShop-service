using EShop.Identity.DTOS;
using EShop.Identity.IService;
using EShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace EShop.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return StatusCode(StatusCodes.Status400BadRequest);
            try
            {
                var userDTOResponse = await _accountService.LoginAsync(loginDTO);
                if (userDTOResponse.Status == ResponseStatus.Unauthorized)
                    return BadRequest(userDTOResponse.Messages);
                return Ok(userDTOResponse.Data);
            }
            catch (Exception ex)
            {
                //TODO : Log exception
                return StatusCode((int)HttpStatusCode.InternalServerError, "Exception has been thrown while registering new users.");
            }
        }
    }
}
