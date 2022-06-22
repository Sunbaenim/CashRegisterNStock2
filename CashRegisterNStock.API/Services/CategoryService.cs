using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.Mappers;
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
            return _dc.Categories.Include("Products").Select(c => c.ToCategoryIndexDTO()).ToList();
        }

        public IEnumerable<CategoryWithoutProductsDTO> GetCategoriesWithoutProducts()
        {
            return _dc.Categories.Select(c => c.ToCategoryWithoutProductsDTO());
        }

        public int CreateCategory(CategoryAddDTO form)
        {
            if (_dc.Categories.ToList().Exists(c => c.Name == form.Name))
            {
                throw new ArgumentException($"The category \"{form.Name}\" already exists");
            }

            Category categoryToAdd = form.ToCategory();
            _dc.Categories.Add(categoryToAdd);

            _dc.SaveChanges();
            return categoryToAdd.Id;
        }

        public int UpdateCategory(int categoryId, CategoryUpdateDTO form)
        {
            Category? category = _dc.Categories.Find(categoryId);
            if (category is null)
            {
                throw new ArgumentException($"No category with the id \"{categoryId}\" was found");
            }
            if (_dc.Categories.ToList().Exists(c => c.Name == form.Name))
            {
                throw new ArgumentException($"The category \"{form.Name}\" already exists");
            }
            category.Name = form.Name;

            _dc.SaveChanges();
            return category.Id;
        }

        public int DeleteCategory(int categoryId)
        {
            Category? category = _dc.Categories.Find(categoryId);
            if (category is null)
            {
                throw new ArgumentException($"No category with the id \"{categoryId}\" was found");
            }
            _dc.Categories.Remove(category);

            _dc.SaveChanges();
            return category.Id;
        }
    }
}
