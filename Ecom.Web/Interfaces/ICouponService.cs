using Ecom.Shared.CommonService.Dtos;
using Ecom.Web.Models;
using System.Globalization;

namespace Ecom.Web.Interfaces
{
    public interface ICouponService 
    {
        Task<CouponDto> GetCuponByCodeAsync(string couponCode);
        Task<List<CouponDto>> GetAllCuponsAsync();
        Task<CouponDto> GetCuponByIdAsync(int couponId);
        Task<CouponDto> CreateCouponAsync(CouponDto createdCoupon);
        Task<CouponDto> UpdateCouponAsync(CouponDto updatedCoupon);
        Task<CouponDto> DeleteCouponAsync(int couponId);
    }
}
