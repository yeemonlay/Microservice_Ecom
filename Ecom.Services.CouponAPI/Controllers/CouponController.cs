using AutoMapper;
using Ecom.Services.CouponAPI.Data;
using Ecom.Services.CouponAPI.Helpers;
using Ecom.Services.CouponAPI.Models;
using Ecom.Shared.CommonService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Ecom.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly CouponDBContext _ctx;
        private readonly IMapper _mapper;
        private ResponseDto response;
        public CouponController(CouponDBContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
            response = new ResponseDto();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Ecom.Services.CouponAPI.Models.Coupon> couponList = _ctx.Coupons.ToList();
                response.Result = _mapper.Map<List<CouponDto>>(couponList);
                response.IsSuccess = couponList.Any();
                response.Message = couponList.Any() ? "Success" : "No Coupon Avaliable";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("No Coupon Avaliable");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try
            {
                //Coupon coupon = _ctx.Coupons.FirstOrDefault(c => c.CouponId == id);
                Coupon couponObj = _ctx.Coupons.Find(id);
                response.Result = _mapper.Map<CouponDto>(couponObj);
                response.IsSuccess = !couponObj.IsNull();
                response.Message = !couponObj.IsNull() ? "Success" : "No Coupon Found";
                return Ok(response);
            }
            catch
            {

                return NotFound("No Coupon Found");
            }
        }

        [HttpGet("/GetByCode/{code}")]
        public IActionResult GetByCode(string code)
        {
            try
            {
                Coupon couponObj = _ctx.Coupons.Where(c => c.CouponCode == code.ToLower()).FirstOrDefault();
                response.Result = _mapper.Map<CouponDto>(couponObj);
                response.IsSuccess = !response.Result.IsNull();
                response.Message = !response.Result.IsNull() ? "Success" : "No Coupon Found";
                return Ok(response);
            }
            catch
            {
                return NotFound("No Coupon Found");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon couponObj = _mapper.Map<Coupon>(coupon);
                _ctx.Coupons.Add(couponObj);
                _ctx.SaveChanges();
                response.Result = couponObj;
                response.IsSuccess = !couponObj.IsNull();
                response.Message = !response.Result.IsNull() ? "Coupon created successfully" : "Coupon creation failed";
                return Created("Get", response);
            }
            catch (Exception ex)
            {
                return NotFound("Coupon creation failed");
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] CouponDto coupon)
        {
            try
            {
                Coupon couponObj = _mapper.Map<Coupon>(coupon);
                Coupon existingCoupon = _ctx.Coupons.Find(couponObj.CouponId);
                if (existingCoupon == null)
                    return NotFound("Coupon Not Found");
                existingCoupon.CouponCode = couponObj.CouponCode;
                existingCoupon.DiscountAmount = couponObj.DiscountAmount;
                existingCoupon.MinAmount = couponObj.MinAmount;
                _ctx.Coupons.Update(existingCoupon);
                _ctx.SaveChanges();
                response.Result = existingCoupon;
                response.IsSuccess = !response.Result.IsNull();
                response.Message = !response.Result.IsNull() ? "Coupon updated successfully" : "Coupon updating failed";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("Coupon updating failed");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Coupon coupon = _ctx.Coupons.Find(id);
                if (coupon == null)
                    return NotFound("Coupon Not Found");
                _ctx.Coupons.Remove(coupon);
                _ctx.SaveChanges();
                response.Result = coupon;
                response.IsSuccess = !coupon.IsNull();
                response.Message = !response.Result.IsNull() ? "Coupon deleted successfully" : "Coupon deleting failed";
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound("Coupon deleting failed");
            }
        }
    }
}
