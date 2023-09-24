using Microsoft.EntityFrameworkCore;
using SimWars.Server.Data;
using SimWars.Shared.Models;

namespace SimWars.Server.Services {
  public class UserTeamService : IUserTeamService {
    readonly SimWarsContext _dbContext = new();

    public UserTeamService(SimWarsContext dbContext) {
      _dbContext = dbContext;
    }

    public List<UserTeam> GetAll() {
      return _dbContext.UserTeams.ToList();
    }

    public void Add(UserTeam userTeam) {
      _dbContext.UserTeams.Add(userTeam);
      _dbContext.SaveChanges();
    }

    public void Update(UserTeam userTeam) {
      _dbContext.Entry(userTeam).State = EntityState.Modified;
      _dbContext.SaveChanges();
    }

    public UserTeam GetById(int id) {
      UserTeam? userTeam = _dbContext.UserTeams.Find(id);
      if (userTeam != null) {
        return userTeam;
      } else {
        return new UserTeam();
      }
    }

    public void Delete(int id) {
      UserTeam? userTeam = _dbContext.UserTeams.Find(id);
      if (userTeam != null) {
        _dbContext.UserTeams.Remove(userTeam);
        _dbContext.SaveChanges();
      }
    }

  }
}
