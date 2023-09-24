using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SimWars.Server.Services;
using SimWars.Shared.Models;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SimWars.Server.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class PlayerController : ControllerBase {
    private readonly IPlayerService _IPlayer;

    public PlayerController(IPlayerService iPlayer) {
      _IPlayer = iPlayer;
    }

    [HttpGet]
    public async Task<List<Player>> GetAll() {
      return await Task.FromResult(_IPlayer.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
      Player player = _IPlayer.GetById(id);
      if (player != null) {
        return Ok(player);
      }
      return NotFound();
    }

    [HttpPost]
    public void Post(Player player) {
      _IPlayer.Add(player);
    }

    [HttpPut]
    public void Put(Player player) {
      _IPlayer.Update(player);
    }

    [HttpDelete]
    public IActionResult Delete(int id) {
      _IPlayer.Delete(id);
      return Ok();
    }
  }
}
