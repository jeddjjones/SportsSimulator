using SimWars.Shared.Models;

namespace SimWars.Server.Services;
public interface IPlayerService {
  public List<Player> GetAll();
  public void Add(Player player);
  public void Update(Player player);
  public Player GetById(int id);
  public void Delete(int id);
}
