﻿using Catalog.Models;

namespace Basket.ApiClient
{
    public class CatalogApiClient(HttpClient httpClient)
    {
        public async Task<Product> GetProductById(int id)
        {
            var response = await httpClient.GetFromJsonAsync<Product>($"/products/{id}");
            return response!;
        }
    }
}
