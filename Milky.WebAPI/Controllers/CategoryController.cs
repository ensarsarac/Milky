using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milky.BusinessLayer.Abstract;
using Milky.DtoLayer.CategoryDtos;
using Milky.EntityLayer.Concrete;

namespace Milky.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _categoryService.TGetList();
			var result = values.Select(x => new ResultCategoryDto()
			{
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName
			}).ToList();

            return Ok(result);
		}
		[HttpPost]
		public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
		{
			_categoryService.TInsert(new Category
			{
				CategoryName = createCategoryDto.CategoryName,
			});
			return Ok("Kategori eklendi");
		}
		[HttpDelete]
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.TDelete(id);
			return Ok("Kategori silindi");
		}
		[HttpPut]
		public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
		{
			var value = _categoryService.TGetById(updateCategoryDto.CategoryId);
			value.CategoryName = updateCategoryDto.CategoryName;
			_categoryService.TUpdate(value);
			return Ok("Kategori güncellendi.");
		}
		[HttpGet("GetCategory")]
		public IActionResult GetCategory(int id)
		{
			return Ok(_categoryService.TGetById(id));
		}
	}
}
