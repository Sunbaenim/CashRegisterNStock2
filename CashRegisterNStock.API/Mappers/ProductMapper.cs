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
                ImageUrl = entity.ImageUrl ?? "assets/products/no-image.png",
                Description = entity.Description,
                Price = entity.Price,
                Stock = entity.Stock
            };
        }

        public static Product ToProduct(this ProductAddDTO dto, string imageUrlToAdd)
        {
            return new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                ImageUrl = imageUrlToAdd ?? "assets/products/no-image.png",
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };
        }

        public static Product ToProduct(this ProductUpdateDTO dto, string imageUrlToAdd)
        {
            return new Product
            {
                CategoryId = dto.CategoryId,
                Name = dto.Name,
                ImageUrl = imageUrlToAdd ?? "assets/products/no-image.png",
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };
        }
    }
}
