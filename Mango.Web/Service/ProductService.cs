using Mango.Web.Model;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using System;

namespace Mango.Web.Service
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;
        private const string _productControllerApi = "/api/productapi";

        public ProductService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = productDto,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}"
            });
        }

        public async Task<ResponseDto?> DeleteProductsAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}/{id}"
            });
        }

        public async Task<ResponseDto?> GetAllProductsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}"
            });
        }

        public async Task<ResponseDto?> GetCouponAsync(string couponCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}/{couponCode}"
            });
        }

        public async Task<ResponseDto?> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}/{id}"
            });
        }

        public async Task<ResponseDto?> UpdateProductsAsync(ProductDto productDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = productDto,
                Url = $"{SD.ProductAPIBase}{_productControllerApi}"
            });
        }

        public Task<ResponseDto?> GetProductAsync(string productCode)
        {
            throw new NotImplementedException();
        }

    }
}