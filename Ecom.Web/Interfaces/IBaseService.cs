using Ecom.Shared.CommonService.Dtos;
using Ecom.Web.Models;

namespace Ecom.Web.Interfaces
{
    public interface IBaseService
    {
        Task<ResponseDto> SendRequestAsync(RequestDto requestDto);
    }
}
