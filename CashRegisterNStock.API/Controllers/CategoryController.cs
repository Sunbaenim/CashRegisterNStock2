using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.API.Services;
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

        [HttpPost]
        public IActionResult CreateCategory(CategoryAddDTO form)
        {
            try
            {
                return Ok(_cs.CreateCategory(form));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, CategoryUpdateDTO form)
        {
            try
            {
                return Ok(_cs.UpdateCategory(categoryId, form));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            try
            {
                return Ok(_cs.DeleteCategory(categoryId));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
