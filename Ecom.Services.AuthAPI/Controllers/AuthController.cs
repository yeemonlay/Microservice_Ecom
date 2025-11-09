using Ecom.Services.AuthAPI.Interface;
using Ecom.Shared.CommonService.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Services.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDto response;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginUser)
        {
            var resultObj = await _authService.Login(loginUser);
            response = new ResponseDto
            {
                IsSuccess = resultObj.Token == string.Empty ? false : true,
                Result = resultObj,
                Message = resultObj.Token == string.Empty ? "Fail" : "Success",
            };
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser)
        {
            string  resultMsg =  await _authService.Register(registerUser);
            if(resultMsg != "")
            {
                response = new ResponseDto
                {
                    IsSuccess = false,
                    Result = null,
                    Message = resultMsg
                };
                return BadRequest(response);
            }
            else
            {
                 response = new ResponseDto
                 {
                        IsSuccess = true,
                        Result = null,
                        Message = "Registration Susccessful"
                 };
                return Ok(response);
            }
        }
    }
}
