using AutoMapper;
using Ecom.Services.CouponAPI.Models;
using Ecom.Shared.CommonService.Dtos;

namespace Ecom.Services.CouponAPI.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Coupon, CouponDto>();
            CreateMap<CouponDto, Coupon>();
        }
    }
}
