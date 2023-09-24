using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using SimWars.Server.Services;
using SimWars.Shared.Models;
using Route = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace SimWars.Server.Controllers {
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
			StoreItemPrize storeItemPrize = _IStoreItemPrize.GetById(id);
			if (storeItemPrize != null) {
				return Ok(storeItemPrize);
			}
			return NotFound();
		}

		[HttpPost]
		public void Post(StoreItemPrize storeItemPrize) {
			_IStoreItemPrize.Add(storeItemPrize);
		}

		[HttpPut]
		public void Put(StoreItemPrize storeItemPrize) {
			_IStoreItemPrize.Update(storeItemPrize);
		}

		[HttpDelete]
		public IActionResult Delete(int id) {
			_IStoreItemPrize.Delete(id);
			return Ok();
		}
	}
}
