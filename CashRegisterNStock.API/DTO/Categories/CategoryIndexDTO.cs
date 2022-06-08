using CashRegisterNStock.API.DTO.Products;
using System.Collections.Generic;

namespace CashRegisterNStock.API.DTO.Categories
{
    public class CategoryIndexDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ProductIndexDTO> Products { get; set; }
    }
}
