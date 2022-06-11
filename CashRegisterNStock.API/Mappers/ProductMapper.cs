using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.DAL.Entities;

namespace CashRegisterNStock.API.Mappers
{
    static class ProductMapper
    {
        public static ProductIndexDTO ToProductIndexDTO(this Product entity)
        {
            return new ProductIndexDTO
            {
                Id = entity.Id,
                CategoryId = entity.CategoryId,
                Name = entity.Name,
                ImageURL = entity.ImageUrl ?? "assets/products/no-image.png",
                Description = entity.Description,
                Price = entity.Price,
                Stock = entity.Stock
            };
        }
    }
}
