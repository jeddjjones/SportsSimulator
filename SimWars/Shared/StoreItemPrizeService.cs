using SimWars.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class StoreItemPrizeService {
	private string _baseUri = "https://localhost:7113/";
	private HttpClient _httpClient;

	public StoreItemPrizeService() {
		_httpClient = new HttpClient();
	}

	public async Task<List<StoreItemPrize>> GetAll() {
		var response = await _httpClient.GetAsync($"{_baseUri}api/storeitemprize");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<List<StoreItemPrize>>();
	}

	public async Task Add(StoreItemPrize storeItemPrize) {
		var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/storeitemprize", storeItemPrize);
		response.EnsureSuccessStatusCode();
	}

	public async Task Update(StoreItemPrize storeItemPrize) {
		var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/storeitemprize", storeItemPrize);
		response.EnsureSuccessStatusCode();
	}
}
