using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.ProductDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}
		[HttpGet]
		public IActionResult ProductList()
		{
			return Ok(_productService.TGetList());
		}
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
			var values = _productService.TGetProductListWithCategory();
			var result = values.Select(x => new ResultProductWithCategoryDto
			{
				CategoryId = x.CategoryId,
				ImageUrl = x.ImageUrl,
				NewPrice = x.NewPrice,
				OldPrice = x.OldPrice,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				Status = x.Status,
				CategoryName=x.Category.CategoryName,
			}).ToList();
            return Ok(result);
        }
        [HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			_productService.TInsert(new Product
			{
				ProductName = createProductDto.ProductName,
				ImageUrl = createProductDto.ImageUrl,
				NewPrice = createProductDto.NewPrice,
				OldPrice = createProductDto.OldPrice,
				Status = createProductDto.Status,
				CategoryId=createProductDto.CategoryId,
				
			});
			return Ok("Ürün eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteProduct(int id)
		{
			_productService.TDelete(id);
			return Ok("Ürün silindi");
		}
		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			var value = _productService.TGetById(updateProductDto.ProductId);
			value.ProductName = updateProductDto.ProductName;
			value.ProductId = updateProductDto.ProductId;
			value.Status = updateProductDto.Status;
			value.OldPrice = updateProductDto.OldPrice;
			value.NewPrice = updateProductDto.NewPrice;
			value.ImageUrl = updateProductDto.ImageUrl;
			value.CategoryId = updateProductDto.CategoryId;
			_productService.TUpdate(value);
			return Ok("Ürün güncellendi.");
		}
		[HttpGet("GetProduct")]
		public IActionResult GetProduct(int id)
		{
			var values = _productService.TGetById(id);
            return Ok(values);
		}
        [HttpGet("GetProductWithCategory")]
        public IActionResult GetProductWithCategory(int id)
        {
            var values = _productService.TGetByIdProductWithCategory(id);
            var result = new ResultProductWithCategoryDto()
            {
                CategoryId = values.CategoryId,
                CategoryName = values.Category.CategoryName,
                ProductName = values.ProductName,
                ImageUrl = values.ImageUrl,
                NewPrice = values.NewPrice,
                OldPrice = values.OldPrice,
                Status = values.Status,
                ProductId = values.ProductId
            };
            return Ok(result);
        }
    }
}
