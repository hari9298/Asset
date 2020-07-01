using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.Exceptions.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.ORM.Entity.UserAdmin;
using Asset.Framework.Repository;

namespace Asset.BO.UserAdmin
{
    public class ProductBO
    {
        ProductRepository productRepository = new ProductRepository();
        public static List<CommonList> productCategories;

        public List<CommonList> GetProductCategories()
        {
            productCategories = productRepository.ProductCategories();
            return productCategories;

        }

        public List<Product> GetProducts()
        {
            var Result =  productRepository.GetProductDetails();
            return Result;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var Result = await productRepository.AddProductDetail(product);
            return Result;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var Result = await productRepository.UpdateProductDetail(product);
            return Result;
        }

        public async Task<Product> DeleteProduct(int productId)
        {
            var Result = await productRepository.DeleteProductDetail(productId);
            return Result;
        }
    }
}

