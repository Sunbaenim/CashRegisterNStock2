using CashRegisterNStock.API.DTO.Categories;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.API.Mappers
{
    static class CategoryMapper
    {
        public static Category ToCategory(this CategoryAddDTO dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }

        public static Category ToCategory(this CategoryUpdateDTO dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }

        public static CategoryIndexDTO ToCategoryIndexDTO(this Category entity)
        {
            return new CategoryIndexDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Products = entity.Products.Select(p => p.ToProductIndexDTO()).ToList()
            };
        }
    }
}
