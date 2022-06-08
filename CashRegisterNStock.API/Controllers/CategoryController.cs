using CashRegisterNStock.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CashRegisterNStock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _cs;

        public CategoryController(CategoryService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public IActionResult GetCategoriesWithProducts()
        {
            return Ok(_cs.GetCategoriesWithProducts());
        }
    }
}
