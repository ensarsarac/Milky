﻿using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.SocialMediaDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
	public class _SocialMediaComponent:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _SocialMediaComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{

			var client = _httpClientFactory.CreateClient();
			var res = await client.GetAsync("https://localhost:7226/api/SocialMedia");
			if (res.IsSuccessStatusCode)
			{
				var read = await res.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(read);
				return View(values);
			}
			return View();
		}
	}
}
