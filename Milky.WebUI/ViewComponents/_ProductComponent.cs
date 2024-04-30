﻿using Microsoft.AspNetCore.Mvc;
using Milky.WebUI.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace Milky.WebUI.ViewComponents
{
    public class _ProductComponent:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _ProductComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var res = await client.GetAsync("https://localhost:7226/api/Product");
            if (res.IsSuccessStatusCode)
            {
                var read = await res.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(read);
                return View(values);
            }
            return View();
        }
    }
}
