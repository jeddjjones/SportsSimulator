using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimWars.Shared.Models;
using SimWars.Server.Services;

namespace SimWars.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreItemPrizeController : ControllerBase {
	private readonly IStoreItemPrizeService _IStoreItemPrize;

	public StoreItemPrizeController(IStoreItemPrizeService iStoreItemPrize) {
		_IStoreItemPrize = iStoreItemPrize;
	}

	[HttpGet]
	public async Task<List<StoreItemPrize>> GetAll() {
		return await Task.FromResult(_IStoreItemPrize.GetAll());
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id) {
		StoreItemPrize StoreItemPrize = _IStoreItemPrize.GetById(id);
		if (StoreItemPrize != null) {
			return Ok(StoreItemPrize);
		}
		return NotFound();
	}

	[HttpPost]
	public void Post(StoreItemPrize StoreItemPrize) {
		_IStoreItemPrize.Add(StoreItemPrize);
	}

	[HttpPut]
	public void Put(StoreItemPrize StoreItemPrize) {
		_IStoreItemPrize.Update(StoreItemPrize);
	}

	[HttpDelete]
	public IActionResult Delete(int id) {
		_IStoreItemPrize.Delete(id);
		return Ok();
	}
}
