using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashRegisterNStock.API.Services
{
    public class CategoryService
    {
        private readonly CrnsDbContext _dc;

        public CategoryService(CrnsDbContext dc)
        {
            _dc = dc;
        }

        public IEnumerable<CategoryIndexDTO> GetCategoriesWithProducts()
        {
            return _dc.Categories.Include(c => c.Products).Select(c => new CategoryIndexDTO
            {
                Id = c.Id,
                Name = c.Name,
                Products = _dc.Products.Where(p => p.CategoryId == c.Id).Select(p => new ProductIndexDTO
                {
                    Id = p.Id,
                    CategoryId = p.CategoryId,
                    Name = p.Name,
                    ImageURL = p.ImageUrl ?? "assets/products/no-image.png",
                    Description = p.Description,
                    Price = p.Price,
                    Stock = p.Stock
                }).ToList()
            });
        }
    }
}
