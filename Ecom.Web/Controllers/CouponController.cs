using Ecom.Shared.CommonService.Dtos;
using Ecom.Web.Interfaces;
using Ecom.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Web.Controllers
{
    public class CouponController : Controller
    {
        private readonly ILogger<CouponController> _logger;
        private readonly ICouponService _couponService;
        public CouponController(ILogger<CouponController> logger, ICouponService couponService)
        {
            _logger = logger;
            _couponService = couponService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> _getCouponList()
        {
            var result = await _couponService.GetAllCuponsAsync();
            return PartialView("_ListCoupon", result);
        }
        public async Task<IActionResult> _UpsertCoupon(int couponId)
        {
            if (couponId == 0)
            {
                CouponDto couponObj = new CouponDto();
                return PartialView("_UpsertCoupon", couponObj);
            }
            else
            {
                CouponDto exisitngCouponObj = await _couponService.GetCuponByIdAsync(couponId);
                return PartialView("_UpsertCoupon", exisitngCouponObj);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DoUpsert(CouponDto couponObj)
        {
            if (couponObj.CouponId == 0)
            {
                var result = await _couponService.CreateCouponAsync(couponObj);
                return Json(result);
            }
            else
            {
                var result = await _couponService.UpdateCouponAsync(couponObj);
                return Json(result);
            }

        }

        public async Task<IActionResult> DoDelete(int couponId)
        {
            var result = await _couponService.DeleteCouponAsync(couponId);
            return Json(result);
        }

    }
}
