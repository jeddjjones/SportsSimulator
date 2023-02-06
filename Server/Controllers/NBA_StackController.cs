using Microsoft.AspNetCore.Mvc;
using SportsSimulator.Shared.Models;
using SportsSimulator.Server.Services;

namespace SportsSimulator.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NBA_StackController : ControllerBase {
	private readonly INBA_StackService _INBA_Stack;

	public NBA_StackController(INBA_StackService iNBA_Stack) {
		_INBA_Stack = iNBA_Stack;
	}

	[HttpGet]
	public async Task<List<NBA_Stack>> Get() {
		return await Task.FromResult(_INBA_Stack.GetStacks());
	}

	[HttpGet("{stackId}")]
	public IActionResult Get(int stackId) {
		NBA_Stack stack = _INBA_Stack.GetStack(stackId);
		if (stack != null) {
			return Ok(stack);
		}
		return NotFound();
	}

	[HttpPost]
	public void Post(NBA_Stack stack) {
		_INBA_Stack.AddStack(stack);
	}

	[HttpPut]
	public void Put(NBA_Stack stack) {
		_INBA_Stack.UpdateStack(stack);
	}

	[HttpDelete]
	public IActionResult Delete(int stackId) {
		_INBA_Stack.DeleteStack(stackId);
		return Ok();
	}
}
