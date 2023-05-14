using SimWars.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared;
public class StoreItemPrizeService {
	private string _baseUri = "https://localhost:7057/";
	private HttpClient _httpClient;

	public StoreItemPrizeService() {
		_httpClient = new HttpClient();
	}

	public async Task<List<StoreItemPrize>> GetAll() {
		var response = await _httpClient.GetAsync($"{_baseUri}api/storeitemprize");
		response.EnsureSuccessStatusCode();
		return await response.Content.ReadFromJsonAsync<List<StoreItemPrize>>();
	}
}
