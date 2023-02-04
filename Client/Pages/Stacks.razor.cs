
using SportsSimulator.Shared;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Client.Pages;

public partial class Stacks {
	private List<Player> NBA_Players = new List<Player>();
	private List<NBA_Stack> NBA_Stacks = new List<NBA_Stack>();
	private NBA_StackService StackService = new NBA_StackService();

	protected override async Task OnInitializedAsync() {
		NBA_Players = await new PlayerService().GetPlayerList("NBA");
		NBA_Stacks = await StackService.GetStackList();
	}

	private async void AddStack() {
		NBA_Stack newStack = new() {
			PG_PlayerId = -1, SG_PlayerId = -1, SF_PlayerId = -1, PF_PlayerId = -1, C_PlayerId = -1,
			G_PlayerId = -1, F_PlayerId = -1, U_PlayerId = -1
		};
		await StackService.Add(newStack);
		NBA_Stacks = await StackService.GetStackList();
		StateHasChanged();
	}

}