using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.TestimonialDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _TestimonialComponent:ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _TestimonialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
        {
			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7226/api/Testimonial");
			if (res.IsSuccessStatusCode)
			{
				var read = await res.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(read);
				return View(values);
			}
			return View();
		}
    }
}
