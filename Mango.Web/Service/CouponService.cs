using Mango.Web.Model;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System;

namespace Mango.Web.Service
{
    public class CouponService : ICouponService
    {
        private readonly IBaseService _baseService;
        private const string _couponControllerApi = "/api/couponapi";

        public CouponService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = couponDto,
                Url =$"{SD.CouponAPIBase}{_couponControllerApi}"
            });
        }

        public async Task<ResponseDto?> DeleteCouponsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{SD.CouponAPIBase}{_couponControllerApi}/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllCouponsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CouponAPIBase}{_couponControllerApi}"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CouponAPIBase}{_couponControllerApi}/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetCouponByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.CouponAPIBase}{_couponControllerApi}/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateCouponsAsync(CouponDto couponDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = couponDto,
                Url = $"{SD.CouponAPIBase}{_couponControllerApi}"
            });
        }
    }
}