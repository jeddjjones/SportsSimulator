using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Services
{
    public interface IPlayerService
    {
        public List<Player> GetPlayers();
        public void AddPlayer(Player player);
        public void UpdatePlayer(Player player);
        public Player GetPlayer(int playerId);
        public void DeletePlayer(int playerId);
    }
}
