using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Milky.WebUI.Areas.Admin.Dtos.CategoryDtos;
using Milky.WebUI.Areas.Admin.Dtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;

namespace Milky.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Product/ProductListWithCategory");
            var readData = await res.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultProductDto>>(readData);
            return View(jsonData);
        }
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7226/api/Product?id=" + id);
            return RedirectToAction("Index");
        }
        public IActionResult CreateProduct()
        {
            ViewBag.categories = new SelectList(GetCategoryList().Result, "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            createProductDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductDto);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PostAsync("https://localhost:7226/api/Product", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            ViewBag.categories = new SelectList(GetCategoryList().Result, "CategoryId", "CategoryName");
            return View(createProductDto);
        }
        public async Task<IActionResult> UpdateProduct(int id)
        {
            ViewBag.categories = new SelectList(GetCategoryList().Result, "CategoryId", "CategoryName");
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Product/GetProduct?id=" + id);
            if (res.IsSuccessStatusCode)
            {
                var readData = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(readData);
                return View(values);
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProduct)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProduct);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var res = await client.PutAsync("https://localhost:7226/api/Product", content);
            if (res.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");

            }
            ViewBag.categories = new SelectList(GetCategoryList().Result, "CategoryId", "CategoryName");
            return View(updateProduct);
        }

        public async Task<List<ResultCategoryDto>> GetCategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Category");
            var readData = await res.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(readData);
            return jsonData;
        }
    }
}
