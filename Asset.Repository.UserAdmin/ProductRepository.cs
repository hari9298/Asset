using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asset.Framework.Repository;
using Asset.ORM.Entity.UserAdmin;
using Asset.Model.UserAdmin;
using Microsoft.EntityFrameworkCore;
using Asset.Repository.Common;



namespace Asset.Repository.UserAdmin
{
    public class ProductRepository : Repository<TProductMaster>, IProductRepository
    {
        public ProductRepository()
        {
            dbContext = new useradminContext();
        }
        public List<CommonList> ProductCategories()
        {
                var categories = from c in dbContext.Set<TProductCategoryMaster>()
                                 select new CommonList
                                 {
                                     ItemID = c.Id,
                                     ItemName = c.Type
                                 };
                return (categories.ToList());
        }

        public List<Product> GetProductDetails()
        {
            var query = from productDetails in dbContext.Set<TProductMaster>().Where(a => a.Status == (int)RecordStatus.Active)
                        join category in dbContext.Set<TProductCategoryMaster>() on productDetails.CatId equals category.Id into productCat
                        from categoryDetails in productCat.DefaultIfEmpty()
                        select new Product
                        {
                            Id = productDetails.Id,
                            ProductCode = productDetails.ProdId,
                            ProductName = productDetails.Name,
                            ProductPrice = productDetails.Price,
                            ProductDescription = productDetails.Description,
                            ProductQuantity = productDetails.Quantity,
                            ProductCategoryId = productDetails.CatId,
                            ProductCategoryName = categoryDetails.Type,
                            CreatedBy = productDetails.CreatedBy,
                            CreatedOn = productDetails.CreatedOn,
                            ModifiedOn = productDetails.ModifiedOn,
                            ModifiedBy = productDetails.ModifiedBy
                        };

            return (query.OrderByDescending(o => o.Id).ToList());
        }

        public Product GetProductDetailsById(int productId)
        {
            var productbyId = new Product();
            var query = from productDetails in dbContext.Set<TProductMaster>().Where(a => (a.Status == (int)RecordStatus.Active) && (a.Id == productId))
                            join category in dbContext.Set<TProductCategoryMaster>() on productDetails.CatId equals category.Id into productCat
                            from categoryDetails in productCat.DefaultIfEmpty()
                            select new Product
                            {
                                Id = productDetails.Id,
                                ProductCode = productDetails.ProdId,
                                ProductName = productDetails.Name,
                                ProductPrice = productDetails.Price,
                                ProductDescription = productDetails.Description,
                                ProductQuantity = productDetails.Quantity,
                                ProductCategoryId = productDetails.CatId,
                                ProductCategoryName = categoryDetails.Type,
                                CreatedBy = productDetails.CreatedBy,
                                CreatedOn = productDetails.CreatedOn,
                                ModifiedOn = productDetails.ModifiedOn,
                                ModifiedBy = productDetails.ModifiedBy

                            };

            var Query = query.FirstOrDefault();
            var Result = (productId != 0) ? Query : productbyId;
            return Result;
        }

        #region SaveProduct

        public async Task<Product> AddProductDetail(Product product)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var Result = ProductMapper.ConvertToProductEntity(product);
            Result.Status = (int)RecordStatus.Active;
            await base.Add(Result);
            userUnitOfWork.Save();
            return GetProductDetailsById(Result.Id);
        }
        #endregion

        #region UpdateProduct
        public async Task<Product> UpdateProductDetail(Product product)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var Result = ProductMapper.ConvertToProductEntity(product);
            Result.Status = (int)RecordStatus.Active;
            await base.Update(Result);
            userUnitOfWork.Save();
            return GetProductDetailsById(Result.Id);
        }
        #endregion

        #region DeleteProduct
        public async Task<Product> DeleteProductDetail(int productId)
        {
            UserUnitOfWork userUnitOfWork = new UserUnitOfWork();
            var productDetails = GetProductDetailsById(productId);
            var Result = ProductMapper.ConvertToProductEntity(productDetails);
            Result.Status = (int)RecordStatus.Inactive;
            await base.Update(Result);
            userUnitOfWork.Save();
            return productDetails;
        }
        #endregion

    }
}
