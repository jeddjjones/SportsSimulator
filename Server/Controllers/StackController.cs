using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportsSimulator.Shared.Models;
using SportsSimulator.Server.Services;

namespace SportsSimulator.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StackController : ControllerBase {
	private readonly IStackService _IStack;

	public StackController(IStackService iStack) {
		_IStack = iStack;
	}

	[HttpGet]
	public async Task<List<Stack>> Get() {
		return await Task.FromResult(_IStack.GetStacks());
	}

	[HttpGet("{stackId}")]
	public IActionResult Get(int stackId) {
		Stack stack = _IStack.GetStack(stackId);
		if (stack != null) {
			return Ok(stack);
		}
		return NotFound();
	}

	[HttpPost]
	public void Post(Stack stack) {
		_IStack.AddStack(stack);
	}

	[HttpPut]
	public void Put(Stack stack) {
		_IStack.UpdateStack(stack);
	}

	[HttpDelete]
	public IActionResult Delete(int stackId) {
		_IStack.DeleteStack(stackId);
		return Ok();
	}
}
