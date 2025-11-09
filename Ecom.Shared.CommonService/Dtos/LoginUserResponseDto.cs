using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Shared.CommonService.Dtos
{
    public class LoginUserResponseDto
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
