using SimWars.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class UserTeamService {
  private string _baseUri = "https://localhost:7113/";
  private HttpClient _httpClient;

  public UserTeamService() {
    _httpClient = new HttpClient();
  }

  public async Task<List<UserTeam>> GetAll() {
    var response = await _httpClient.GetAsync($"{_baseUri}api/userteam");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<List<UserTeam>>();
  }

  public async Task<UserTeam> GetById(int id) {
    var response = await _httpClient.GetAsync($"{_baseUri}api/userteam/{id}");
    response.EnsureSuccessStatusCode();
    return await response.Content.ReadFromJsonAsync<UserTeam>();
  }

  public async Task Add(UserTeam userTeam) {
    var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/userteam", userTeam);
    response.EnsureSuccessStatusCode();
  }

  public async Task Update(UserTeam userTeam) {
    var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/userteam", userTeam);
    response.EnsureSuccessStatusCode();
  }
}
