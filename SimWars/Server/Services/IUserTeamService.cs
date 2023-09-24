using SimWars.Shared.Models;

namespace SimWars.Server.Services;
public interface IUserTeamService {
  public List<UserTeam> GetAll();
  public void Add(UserTeam userTeam);
  public void Update(UserTeam userTeam);
  public UserTeam GetById(int id);
  public void Delete(int id);
}
