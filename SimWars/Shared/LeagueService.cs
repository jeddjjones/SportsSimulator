using SimWars.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class LeagueService {
  private string _baseUri = "https://localhost:7113/";
  private HttpClient _httpClient;

  public LeagueService() {
    _httpClient = new HttpClient();
  }

  public async Task<List<League>> GetAll() {
    var response = await _httpClient.GetAsync($"{_baseUri}api/league");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<List<League>>();
  }

  public async Task<League> GetById(int id) {
    var response = await _httpClient.GetAsync($"{_baseUri}api/league/{id}");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<League>();
  }

  public async Task Add(League userTeam) {
    var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/league", userTeam);
    response.EnsureSuccessStatusCode();
  }

  public async Task Update(League userTeam) {
    var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/league", userTeam);
    response.EnsureSuccessStatusCode();
  }
}
