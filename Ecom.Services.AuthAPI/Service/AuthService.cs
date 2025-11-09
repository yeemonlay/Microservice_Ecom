using AutoMapper;
using Azure;
using Ecom.Services.AuthAPI.Data;
using Ecom.Services.AuthAPI.Interface;
using Ecom.Services.AuthAPI.Models;
using Ecom.Shared.CommonService.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Ecom.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AuthDBContext _ctx;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IJWTGeneratorService _jwtService;
        public AuthService(AuthDBContext ctx, UserManager<User> userManager, RoleManager<IdentityRole> roleManager,IMapper mapper, IJWTGeneratorService jwtService)
        {
            _ctx = ctx;
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _jwtService = jwtService;
        }
        public async Task<LoginUserResponseDto> Login(LoginUserRequestDto loginUser)
        {
            User userObj =  _ctx.Users.FirstOrDefault(u => u.UserName.ToLower() == loginUser.UserName.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(userObj, loginUser.Password);
            if (userObj == null || !isValid)
            {
                return new LoginUserResponseDto
                {
                    User = null,
                    Token = ""
                };
            }
            else
            {
                return new LoginUserResponseDto
                {
                    User = _mapper.Map<UserDto>(userObj),
                    Token = _jwtService.GenerateToken(userObj)
                };
            }
        }

        public async Task<string> Register(RegisterUserDto registerUser)
        {
            try
            {
                User userObj = _mapper.Map<User>(registerUser);
                var result = await _userManager.CreateAsync(userObj,registerUser.Password);
                if (result.Succeeded)
                {
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
             catch
            {
                return "Registration Failed";
            }
        }
    }
}
