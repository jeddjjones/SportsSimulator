using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimWars.Shared.Models;
using SimWars.Server.Services;

namespace SimWars.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StoreItemController : ControllerBase {
	private readonly IStoreItemService _IStoreItem;

	public StoreItemController(IStoreItemService iStoreItem) {
		_IStoreItem = iStoreItem;
	}

	[HttpGet]
	public async Task<List<StoreItem>> GetAll() {
		return await Task.FromResult(_IStoreItem.GetAll());
	}

	[HttpGet("{id}")]
	public IActionResult GetById(int id) {
		StoreItem storeItem = _IStoreItem.GetById(id);
		if (storeItem != null) {
			return Ok(storeItem);
		}
		return NotFound();
	}

	[HttpPost]
	public void Post(StoreItem storeItem) {
		_IStoreItem.Add(storeItem);
	}

	[HttpPut]
	public void Put(StoreItem storeItem) {
		_IStoreItem.Update(storeItem);
	}

	[HttpDelete]
	public IActionResult Delete(int id) {
		_IStoreItem.Delete(id);
		return Ok();
	}
}
