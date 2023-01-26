using Microsoft.AspNetCore.Components;
using SportsSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SportsSimulator.Shared {
	public class StackService {

		private string _baseUri = "https://localhost:7057/";
		private HttpClient _httpClient;

		public StackService() {
			_httpClient = new HttpClient();
		}

		public async Task<List<Stack>> GetStackList() {
			var response = await _httpClient.GetAsync($"{_baseUri}api/stack");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<List<Stack>>();
		}

		public async Task<List<Stack>> GetStackList(string sport) {
			var response = await _httpClient.GetAsync($"{_baseUri}api/stack");
			response.EnsureSuccessStatusCode();
			var resp = await response.Content.ReadFromJsonAsync<List<Stack>>();
			return resp.Where(x => x.Sport == sport && x.Enabled).ToList();
		}

	}
}
