using SportsSimulator.Shared.Models;
using SportsSimulator.Shared;

namespace SportsSimulator.Client.Pages;

public partial class NBA {

	private List<NbaLineup> lineups = new List<NbaLineup>();
	private List<Player> Players = new List<Player>();
	private List<NBA_Stack> Stacks = new List<NBA_Stack>();
	protected override async Task OnInitializedAsync() {
		Players = await new PlayerService().GetPlayerList("NBA");
		Stacks = await new NBA_StackService().GetStackList();
	}

	public void BuildLineups() {

		foreach (var stack in Stacks) {

			var lineup = new NbaLineup(50000);
			var pgid = stack.PG_PlayerId;
			var pg = Players.FirstOrDefault(p => p.PlayerId == stack.PG_PlayerId);
			lineup.Add(Players.FirstOrDefault(p => p.PlayerId == stack.PG_PlayerId), 0);
			lineup.Add(Players.FirstOrDefault(p => p.PlayerId == stack.SG_PlayerId), 1);
			lineup.Add(Players.FirstOrDefault(p => p.PlayerId == stack.SF_PlayerId), 2);
			lineup.Add(Players.FirstOrDefault(p => p.PlayerId == stack.PF_PlayerId), 3);
			lineup.Add(Players.FirstOrDefault(p => p.PlayerId == stack.C_PlayerId), 4);

			var guardPool = lineup.GetPlayerPool(Players.Where(p => p.Position.Contains("G")).ToList());
			foreach (var guard in guardPool) {
				lineup.RemoveToN(5);
				var guardSlot = lineup.CanDraft(guard);
				if (guardSlot > -1) {
					lineup.Add(guard, 5);
					var forwardPool = lineup.GetPlayerPool(Players.Where(p => p.Position.Contains("F")).ToList());
					foreach (var forward in forwardPool) {
						lineup.RemoveToN(6);
						var forwardSlot = lineup.CanDraft(forward);
						if (forwardSlot > -1) {
							lineup.Add(forward, 6);
							var utilPool = lineup.GetPlayerPool(Players);
							foreach (var util in utilPool) {
								lineup.RemoveToN(7);
								var utilSlot = lineup.CanDraft(util);
								if (utilSlot > -1) {
									lineup.Add(util, 7);
									var lineupPlayers = lineup.LineupPlayers;
									if (lineup.IsValid() && lineup.RemainingSalary() < 400 && !lineups.Select(x => x.LineupPlayers).Contains(lineupPlayers)) {
										//valid lineup and not a duplicate, so add it				
										var L = new NbaLineup(50000);
										var i = 0;
										foreach (Player p in lineup.PlayersList.OrderBy(p => p.PlayerNum)) {
											L.Add(p, i);
											i++;
										}
										L.ToLineupString();
										lineups.Add(L);
										Console.WriteLine("LINEUP ADDED: " + L.LineupPlayers + Environment.NewLine);
										Console.WriteLine("LINEUPS TOTAL: " + lineups.Count + Environment.NewLine);
									}
								}
							}
						}
					}
				}
			}
		}
		var numlineups = lineups.Count;
		lineups = lineups.OrderByDescending(lineup => lineup.TotalValue).ToList();
		StateHasChanged();
	}
}