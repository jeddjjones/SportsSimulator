using Microsoft.EntityFrameworkCore;
using SportsSimulator.Server.Models;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services {
	public class PlayerService : IPlayerService {
		readonly SportsSimulatorContext _dbContext = new();

		public PlayerService(SportsSimulatorContext dbContext) {
			_dbContext = dbContext;
		}

		public List<Player> GetPlayers() {
			return _dbContext.Players.ToList();
		}

		public void AddPlayer(Player player) {
			_dbContext.Players.Add(player);
			_dbContext.SaveChanges();
		}

		public void UpdatePlayer(Player player) {
			_dbContext.Entry(player).State = EntityState.Modified;
			_dbContext.SaveChanges();
		}

		public Player GetPlayer(int playerId) {
			Player? player = _dbContext.Players.Find(playerId);
			if (player != null) {
				return player;
			} else {
				return new Player();
			}
		}

		public void DeletePlayer(int playerId) {
			Player? player = _dbContext.Players.Find(playerId);
			if (player != null) {
				_dbContext.Players.Remove(player);
				_dbContext.SaveChanges();
			}
		}

	}
}
