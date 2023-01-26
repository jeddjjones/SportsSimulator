using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSimulator.Shared.Models;
using SportsSimulator.Server.Services;

namespace SportsSimulator.Server.Controllers;

[Route("api/[controller]")]
[ApiController] 
public class SlateController : ControllerBase {
	private readonly ISlateService _ISlate;

	public SlateController(ISlateService iSlate) {
		_ISlate = iSlate;
	}

	[HttpGet]
	public async Task<List<Slate>> Get() {
		return await Task.FromResult(_ISlate.GetSlates());
	}

	[HttpGet("{slateId}")]
	public IActionResult Get(int slateId) {
		Slate slate = _ISlate.GetSlate(slateId);
		if (slate != null) {
			return Ok(slate);
		}
		return NotFound();
	}
	
	[HttpPost]
	public void Post(Slate slate) {
		_ISlate.AddSlate(slate);
	}

	[HttpPut]
	public void Put(Slate slate) {
		_ISlate.UpdateSlate(slate);
	}

	[HttpDelete]
	public IActionResult Delete(int slateId) {
		_ISlate.DeleteSlate(slateId);
		return Ok();
	}
}
