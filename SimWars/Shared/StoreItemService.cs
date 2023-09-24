using SimWars.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class StoreItemService {
  private string _baseUri = "https://localhost:7113/";
  private HttpClient _httpClient;

  public StoreItemService() {
    _httpClient = new HttpClient();
  }

  public async Task<List<StoreItem>> GetAll() {
    var response = await _httpClient.GetAsync($"{_baseUri}api/storeitem");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<List<StoreItem>>();
  }

  public async Task Add(StoreItem storeItem) {
    var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/storeitem", storeItem);
    response.EnsureSuccessStatusCode();
  }

  public async Task Update(StoreItem storeItem) {
    var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/storeitem", storeItem);
    response.EnsureSuccessStatusCode();
  }
}
