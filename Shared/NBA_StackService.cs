using Microsoft.AspNetCore.Components;
using SportsSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace SportsSimulator.Shared {
	public class NBA_StackService {

		private string _baseUri = "https://localhost:7057/";
		private HttpClient _httpClient;

		public NBA_StackService() {
			_httpClient = new HttpClient();
		}

		public async Task<List<NBA_Stack>> GetStackList() {
			var response = await _httpClient.GetAsync($"{_baseUri}api/nba_stack");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadFromJsonAsync<List<NBA_Stack>>();
		}

		public async Task Add(NBA_Stack stack) {
			var response = await _httpClient.PostAsJsonAsync($"{_baseUri}api/nba_stack", stack);
			response.EnsureSuccessStatusCode();			
		}

		public async Task Update(NBA_Stack stack) {
			var response = await _httpClient.PutAsJsonAsync($"{_baseUri}api/nba_stack", stack);
			response.EnsureSuccessStatusCode();
		}

	}
}
