using Core.Abstractions;
using Core.DTOs;
using Core.Entities;
using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTestingPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetProductList")]
        public async Task<ResponseResultDTO> GetProductList()
        {
            var productList = await _productService.GetProductList();
            
            if(productList == null || productList.Count() == 0) 
                return ResponseResultDTO.NotFound();

            return ResponseResultDTO.Ok(productList);
        }

        [HttpGet("GetProductById/{Id}")]
        public async Task<ResponseResultDTO> GetProductById(int Id)
        {
            var product = await _productService.GetProductById(Id);
            if(product == null)
                return ResponseResultDTO.NotFound();

            return ResponseResultDTO.Ok(product);
        }

        [HttpPost("AddProduct")]
        public async Task<ResponseResultDTO> AddProduct([FromBody] Product product)
        {
            var AddedProduct = await _productService.AddProduct(product);
            if (AddedProduct == null)
                return ResponseResultDTO.BadRequest();

            return ResponseResultDTO.Ok(AddedProduct);
        }

        [HttpPut("UpdateProduct")]
        public async Task<ResponseResultDTO> UpdateProduct([FromBody] Product product)
        {
            var UpdatedProduct = await _productService.UpdateProduct(product);
            if (UpdatedProduct == null)
                return ResponseResultDTO.BadRequest();

            return ResponseResultDTO.Ok(UpdatedProduct);
        }

        [HttpDelete("DeleteProductById/{Id}")]
        public async Task<ResponseResultDTO> DeleteProduct(int Id)
        {
            var ProductIsDeleted = await _productService.DeleteProduct(Id);
            if (ProductIsDeleted == false)
                return ResponseResultDTO.NotFound();

            return ResponseResultDTO.Ok(ProductIsDeleted);
        }

    }
}
