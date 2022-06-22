using CashRegisterNStock.API.DTO.Validators;
using System.ComponentModel.DataAnnotations;

namespace CashRegisterNStock.API.DTO.Products
{
    public class ProductAddDTO
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(255)]
        public string Description { get; set; }
        [Required]
        [PositiveValidator]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
    }
}
