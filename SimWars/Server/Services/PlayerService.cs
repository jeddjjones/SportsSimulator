using Microsoft.EntityFrameworkCore;
using SimWars.Server.Data;
using SimWars.Shared.Models;

namespace SimWars.Server.Services {
  public class PlayerService : IPlayerService {
    readonly SimWarsContext _dbContext = new();

    public PlayerService(SimWarsContext dbContext) {
      _dbContext = dbContext;
    }

    public List<Player> GetAll() {
      return _dbContext.Players.ToList();
    }

    public void Add(Player player) {
      _dbContext.Players.Add(player);
      _dbContext.SaveChanges();
    }

    public void Update(Player player) {
      _dbContext.Entry(player).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public Player GetById(int id) {
      Player? player = _dbContext.Players.Find(id);
      if (player != null) {
        return player;
      } else {
        return new Player();
      }
    }

    public void Delete(int id) {
      Player? player = _dbContext.Players.Find(id);
      if (player != null) {
        _dbContext.Players.Remove(player);
        _dbContext.SaveChanges();
      }
    }

  }
}
