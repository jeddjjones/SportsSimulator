using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSimulator.Shared.Models;
using SportsSimulator.Server.Services;

namespace SportsSimulator.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayerController : ControllerBase {
	private readonly IPlayerService _IPlayer;

	public PlayerController(IPlayerService iPlayer) {
		_IPlayer = iPlayer;
	}

	[HttpGet]
	public async Task<List<Player>> Get() {
		return await Task.FromResult(_IPlayer.GetPlayers());
	}

	[HttpGet("{playerId}")]
	public IActionResult Get(int playerId) {
		Player player = _IPlayer.GetPlayer(playerId);
		if (player != null) {
			return Ok(player);
		}
		return NotFound();
	}

	[HttpPost]
	public void Post(Player player) {
		_IPlayer.AddPlayer(player);
	}

	[HttpPut]
	public void Put(Player player) {
		_IPlayer.UpdatePlayer(player);
	}

	[HttpDelete]
	public IActionResult Delete(int playerId) {
		_IPlayer.DeletePlayer(playerId);
		return Ok();
	}
}

