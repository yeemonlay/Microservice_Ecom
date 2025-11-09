using Ecom.Shared.CommonService.Dtos;

namespace Ecom.Services.AuthAPI.Interface
{
    public interface IAuthService
    {
        Task<LoginUserResponseDto> Login(LoginUserRequestDto loginUser);
        Task<string> Register(RegisterUserDto registerUser);
    }
}
