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
	public class PlayerService {

		private string _baseUri = "https://localhost:7057/";
		private HttpClient _httpClient;

		public PlayerService() { 
			_httpClient = new HttpClient();
		}

		public async Task<List<Player>> GetPlayerList() {
			var response = await _httpClient.GetAsync($"{_baseUri}api/player");
			response.EnsureSuccessStatusCode();
			var resp = await response.Content.ReadFromJsonAsync<List<Player>>();
			return resp.Where(x => x.Enabled).ToList();
		}

		public async Task<List<Player>> GetPlayerList(string sport) {
			var response = await _httpClient.GetAsync($"{_baseUri}api/player");
			response.EnsureSuccessStatusCode();
			var resp = await response.Content.ReadFromJsonAsync<List<Player>>();
			return resp.Where(x => x.Sport == sport && x.Enabled).ToList();
		}

		public List<string> GetTeams(List<Player> players) {
			return players.Select(x => x.Team).Distinct().ToList();
		}

		public List<Player> GetDSTs(List<Player> players) {
			return players.Where(x => x.Position == "DST").ToList();
		}

		public Player GetPlayerById(List<Player> players, int playerId) {
			return players.FirstOrDefault(x => x.PlayerId == playerId);
		}
	}
}
