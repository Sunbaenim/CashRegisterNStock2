using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _ps;

        public ProductController(ProductService ps)
        {
            _ps = ps;
        }

        [HttpGet("{productId}")]
        public IActionResult GetProductsWithProducts(int productId)
        {
            try
            {
                return Ok(_ps.GetProductById(productId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductAddDTO form)
        {
            try
            {
                return Ok(_ps.CreateProduct(form));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int productId, ProductUpdateDTO form)
        {
            try
            {
                return Ok(_ps.UpdateProduct(productId, form));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int productId)
        {
            try
            {
                return Ok(_ps.DeleteProduct(productId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
