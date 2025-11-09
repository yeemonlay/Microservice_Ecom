using Ecom.Services.AuthAPI.Models;

namespace Ecom.Services.AuthAPI.Interface
{
    public interface IJWTGeneratorService
    {
        public string GenerateToken(User userObj);
    }
}
