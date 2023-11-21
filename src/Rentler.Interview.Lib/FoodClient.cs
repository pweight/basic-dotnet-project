using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FoodClient : IFoodClient
{
private readonly HttpClient _httpClient;

public FoodClient(HttpClient httpClient)
{
    _httpClient = httpClient;
}


public async Task<PaginatedFoodData> GetPaginatedFoodDataAsync(int pageNumber, int pageSize)
{
    var response = await _httpClient.GetAsync($"food/page/{pageNumber}/size/{pageSize}");

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<PaginatedFoodData>(content);
    }
    else
    {
        throw new Exception($"Unable to retrieve food data: {response.StatusCode}");
    }
}

public async Task<Food> GetFoodByIdAsync(int id)
{
    var response = await _httpClient.GetAsync($"food/{id}");

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Food>(content);
    }
    else
    {
        throw new Exception($"Unable to retrieve food data: {response.StatusCode}");
    }
}

public async Task<Food> CreateFoodAsync(Food food)
{
    var foodJson = JsonConvert.SerializeObject(food);
    var content = new StringContent(foodJson, Encoding.UTF8, "application/json");
    var response = await _httpClient.PostAsync("food", content);

    if (response.IsSuccessStatusCode)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Food>(responseContent);
    }
    else
    {
        throw new Exception($"Unable to create food: {response.StatusCode}");
    }
}

public async Task<Food> UpdateFoodAsync(Food food)
{
    var foodJson = JsonConvert.SerializeObject(food);
    var content = new StringContent(foodJson, Encoding.UTF8, "application/json");
    var response = await _httpClient.PutAsync("food", content);

    if (response.IsSuccessStatusCode)
    {
        var responseContent = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Food>(responseContent);
    }
    else
    {
        throw new Exception($"Unable to update food: {response.StatusCode}");
    }
}

public async Task<bool> DeleteFoodAsync(int id)
{
    var response = await _httpClient.DeleteAsync($"food/{id}");

    if (response.IsSuccessStatusCode)
    {
        return true;
    }
    else
    {
        throw new Exception($"Unable to delete food: {response.StatusCode}");
    }
}

public async Task<SearchFoodData> SearchFoodsAsync(string searchTerm, int pageNumber, int pageSize)
{
    var response = await _httpClient.GetAsync($"food/search/{searchTerm}/page/{pageNumber}/size/{pageSize}");

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<SearchFoodData>(content);
    }
    else
    {
        throw new Exception($"Unable to retrieve food data: {response.StatusCode}");
    }
}
}
