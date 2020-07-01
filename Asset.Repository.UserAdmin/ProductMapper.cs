using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Repository.Common;
using Asset.Model.UserAdmin;
using Asset.ORM.Entity.UserAdmin;

namespace Asset.Repository.UserAdmin
{
    public static class ProductMapper
    {
        public static TProductMaster ConvertToProductEntity(this Product product)
        {
            return new TProductMaster
            {
                Id = product.Id,
                ProdId = product.ProductCode,
                Name = product.ProductName,
                Price = product.ProductPrice,
                Description = product.ProductDescription,
                CatId = product.ProductCategoryId,
                CreatedBy = product.CreatedBy,
                CreatedOn = product.CreatedOn,
                ModifiedBy = product.ModifiedBy,
                ModifiedOn =product.ModifiedOn
            };
        }
    }
}
