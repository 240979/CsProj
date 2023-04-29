using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using ElectronicStorageBlazor.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElectronicStorageBlazor.Data;

public class StorageService
{
    private readonly HttpClient _httpClient;

    public StorageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5182/");
    }

    public async Task<IEnumerable<ItemDto>?> GetItems()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<ItemDto>>("api/Item");
    }

    public async Task <ItemDto?> GetOneItem(Guid id)
    {//<ItemDto?>
        return await _httpClient.GetFromJsonAsync<ItemDto?>($"api/Item/{id}");
    }
    public async Task AddItem(ItemDto itemDto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/Item", itemDto);
    }

    public async Task UpdateItem(Guid id, ItemDto itemDto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/Item/{id}", itemDto);
    }
    
    public async Task DeleteItem(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/Item/{id}");
    }
}