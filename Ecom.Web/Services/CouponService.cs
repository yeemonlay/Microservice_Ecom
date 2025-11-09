using Ecom.Shared.CommonService.Dtos;
using Ecom.Web.Interfaces;
using Ecom.Web.Models;
using Ecom.Web.Utilities;
using Newtonsoft.Json;

namespace Ecom.Web.Services
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<CouponDto> CreateCouponAsync(CouponDto createdCoupon)
        {
            CouponDto result = new();

            var response =  await _baseService.SendRequestAsync(new RequestDto()
            {
                Data = createdCoupon,
                APIType = APIMethod.POST,
                Url = Common.EcomCouponServiceAPI + "api/Coupon"
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
            }
            return result;
        }

        public async Task<CouponDto> DeleteCouponAsync(int couponId)
        {
            CouponDto result = new();
            var response =  await _baseService.SendRequestAsync(new RequestDto()
            {
                APIType = APIMethod.DELETE,
                Url = Common.EcomCouponServiceAPI + "api/Coupon/" + couponId
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
            }
            return result;
        }

        public async Task<List<CouponDto>> GetAllCuponsAsync()
        {
            List<CouponDto> result = new();

            var response =  await _baseService.SendRequestAsync(new RequestDto()
            {
                APIType = APIMethod.GET,
                Url = Common.EcomCouponServiceAPI + "api/Coupon"
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<List<CouponDto>>(jsonResult);
            }
            return result;
        }

        public async Task<CouponDto> GetCuponByCodeAsync(string couponCode)
        {
            CouponDto result = new();

            var response =  await _baseService.SendRequestAsync(new RequestDto()
            {
                APIType = APIMethod.GET,
                Url = Common.EcomCouponServiceAPI + "api/Coupon/GetByCode/" + couponCode
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
            }
            return result;
        }

        public async Task<CouponDto> GetCuponByIdAsync(int couponId)
        {
            CouponDto result = new();

            var response =  await _baseService.SendRequestAsync(new RequestDto() 
            { 
                APIType = APIMethod.GET,
                Url = Common.EcomCouponServiceAPI + "api/Coupon/" + couponId
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
            }
            return result;
        }

        public async Task<CouponDto> UpdateCouponAsync(CouponDto updatedCoupon)
        {
            CouponDto result = new();
            var response =  await _baseService.SendRequestAsync(new RequestDto()
            {
                Data = updatedCoupon,
                APIType = APIMethod.PUT,
                Url = Common.EcomCouponServiceAPI + "api/Coupon"
            });
            if (response.IsSuccess && response.Result != null)
            {
                var jsonResult = response.Result.ToString();
                result = JsonConvert.DeserializeObject<CouponDto>(jsonResult);
            }
            return result;
        }
    }
}
