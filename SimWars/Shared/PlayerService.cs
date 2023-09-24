using SimWars.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class PlayerService {
  private string _baseUri = "https://localhost:7113/";
  private HttpClient _httpClient;

  public PlayerService() {
    _httpClient = new HttpClient();
  }

  public async Task<List<Player>> GetAll() {
    var response = await _httpClient.GetAsync($"{_baseUri}api/player");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<List<Player>>();
  }

  public async Task Add(Player player) {
    var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/player", player);
    response.EnsureSuccessStatusCode();
  }

  public async Task Update(Player player) {
    var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/player", player);
    response.EnsureSuccessStatusCode();
  }
}
