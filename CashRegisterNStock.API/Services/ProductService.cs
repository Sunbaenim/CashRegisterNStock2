using CashRegisterNStock.API.DTO.Products;
using CashRegisterNStock.API.Mappers;
using CashRegisterNStock.DAL;
using CashRegisterNStock.DAL.Entities;
using System.Reflection;

namespace CashRegisterNStock.API.Services
{
    public class ProductService
    {
        private readonly CrnsDbContext _dc;

        public ProductService(CrnsDbContext dc)
        {
            _dc = dc;
        }

        private static string GetFileExtension(string base64String)
        {
            return base64String[..5].ToUpper() switch
            {
                "/9J/4" => "jpg",
                "IVBOR" => "png",
                _ => string.Empty,
            };
        }
        private static string GetImageUrlFromBase64(string baseImageUrl, string productName)
        {
            string base64String = baseImageUrl.Contains(',') ? baseImageUrl.Split(",")[1] : baseImageUrl;
            byte[] base64 = Convert.FromBase64String(base64String);
            string extensionFile = GetFileExtension(base64String);
            Guid guid = Guid.NewGuid();
            string filePath = "assets/products/" + productName + "-" + guid + "." + extensionFile;
            File.WriteAllBytes("wwwroot/" + filePath, base64);
            return filePath;
        }

        public ProductIndexDTO GetProductById(int productId)
        {
            Product? product = _dc.Products.Find(productId);
            if (product is null)
            {
                throw new ArgumentException($"No product with the id \"{productId}\" was found");
            }

            return product.ToProductIndexDTO();
        }

        public int CreateProduct(ProductAddDTO form)
        {
            if (_dc.Products.ToList().Exists(p => p.Name == form.Name && p.Description == form.Description))
            {
                throw new ArgumentException($"The product \"{form.Name} {form.Description}\" already exists");
            }
            string imageUrl = string.Empty;
            if (!string.IsNullOrEmpty(form.ImageUrl))
            {
                try
                {
                    imageUrl = GetImageUrlFromBase64(form.ImageUrl, form.Name);
                }
                catch (Exception)
                {
                    throw new ArgumentException("The encoding of the image has encountered a problem. The encoding must use Base64");
                }
            }
            Product productToAdd = form.ToProduct(imageUrl);
            _dc.Products.Add(productToAdd);

            _dc.SaveChanges();
            return productToAdd.Id;
        }

        public int UpdateProduct(int productId, ProductUpdateDTO form)
        {
            Product? product = _dc.Products.Find(productId);
            if (product is null)
            {
                throw new ArgumentException($"No product with the id \"{productId}\" was found");
            }
            if (_dc.Products.ToList().Exists(p => p.Name.ToLower() == form.Name.ToLower() && p.Description.ToLower() == form.Description.ToLower() && p.Id != form.Id))
            {
                throw new ArgumentException($"The product \"{form.Name} {form.Description}\" already exists");
            }

            foreach (PropertyInfo property in form.GetType().GetProperties())
            {
                if (property.Name == "ImageUrl")
                {
                    string imageUrl = string.Empty;
                    if (!string.IsNullOrEmpty(form.ImageUrl))
                    {
                        try
                        {
                            imageUrl = GetImageUrlFromBase64(form.ImageUrl, form.Name);
                        }
                        catch (Exception)
                        {
                            throw new ArgumentException("The encoding of the image has encountered a problem. The encoding must use Base64");
                        }
                        File.Delete("wwwroot/" + product.ImageUrl);
                        product.GetType().GetProperty(property.Name)?.SetValue(product, imageUrl, null);
                    }
                }
                else
                {
                    product.GetType().GetProperty(property.Name)?.SetValue(product, property.GetValue(form, null), null);
                }
            }

            _dc.SaveChanges();
            return product.Id;
        }

        public int DeleteProduct(int productId)
        {
            Product? product = _dc.Products.Find(productId);
            if (product is null)
            {
                throw new ArgumentException($"No category with the id \"{productId}\" was found");
            }
            _dc.Products.Remove(product);

            _dc.SaveChanges();
            return product.Id;
        }
    }
}
