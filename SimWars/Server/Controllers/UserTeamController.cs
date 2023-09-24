using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SimWars.Server.Services;
using SimWars.Shared.Models;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SimWars.Server.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class UserTeamController : ControllerBase {
    private readonly IUserTeamService _IUserTeam;

    public UserTeamController(IUserTeamService iUserTeam) {
      _IUserTeam = iUserTeam;
    }

    [HttpGet]
    public async Task<List<UserTeam>> GetAll() {
      return await Task.FromResult(_IUserTeam.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
      UserTeam userTeam = _IUserTeam.GetById(id);
      if (userTeam != null) {
        return Ok(userTeam);
      }
      return NotFound();
    }

    [HttpPost]
    public void Post(UserTeam userTeam) {
      _IUserTeam.Add(userTeam);
    }

    [HttpPut]
    public void Put(UserTeam userTeam) {
      _IUserTeam.Update(userTeam);
    }

    [HttpDelete]
    public IActionResult Delete(int id) {
      _IUserTeam.Delete(id);
      return Ok();
    }
  }
}
