using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Asset.BO.UserAdmin;
using Asset.Model.UserAdmin;
using Asset.DTO.UserAdmin;
using Asset.Services.UserAdmin;
using Asset.Exceptions.UserAdmin;
using Microsoft.AspNetCore.Identity;

namespace Asset.BO.UserAdmin
{
    [Produces("application/json")]
    [Route("api/Product")]

    public class ProductController : Controller
    {
        ProductBO productBO = new ProductBO();

        [HttpGet]
        [Route("ProductCategories")]

        public List<CommonListDTO> GetProductCategories()
        {

            var Result = productBO.GetProductCategories();
            var ProductCategoryDTO = ConvertModelToDto.ConvertCommonLstListModeltoDto(Result);
            return ProductCategoryDTO;

        }

        [HttpGet]
        [Route("all")]

        public List<ProductDTO> GetProductDetails()
        {

            var Result = productBO.GetProducts();
            var ProductsDTO = ConvertModelToDto.convertProductListModelToDTO(Result);
            return ProductsDTO;

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ProductDTO product)
        {
            var productDetails = ConvertDtoToModel.ConvertProductDTOToModel(product);
            var Result = productBO.AddProduct(productDetails);
            await Result;
            var productDetailsDTO = ConvertModelToDto.convertProductModelToDTO(Result.Result);

            if (productDetailsDTO != null)
            {
                return Ok(productDetailsDTO);
            }
            else
            {
                return BadRequest(productDetailsDTO);
            }

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]ProductDTO product)
        {
            var productDetails = ConvertDtoToModel.ConvertProductDTOToModel(product);
            var Result = productBO.UpdateProduct(productDetails);
            await Result;
            var productDetailsDTO = ConvertModelToDto.convertProductModelToDTO(Result.Result);

            if (productDetailsDTO != null)
            {
                return Ok(productDetailsDTO);
            }
            else
            {
                return BadRequest(productDetailsDTO);
            }

        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {

            var Result = await productBO.DeleteProduct(productId);
            if (Result != null)
            {
                return Ok(Result);

            }
            else
            {
                return BadRequest(Result);
            }

        }


    }
}