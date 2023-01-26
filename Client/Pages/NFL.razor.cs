using SportsSimulator.Shared;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Client.Pages
{
    public partial class NFL
    {
        private bool fetching;
        private readonly int salaryCap = 50000;
        private List<NflLineup> lineups = new List<NflLineup>();
        List<Player> playerList = new List<Player>();
        protected override async Task OnInitializedAsync()
        {
            playerList = await new PlayerService().GetPlayerList("NFL");
        }

        public async void BuildLineups()
        {
            fetching = true;
            var stacks = await new StackService().GetStackList("NFL");
            foreach (var stack in stacks)
            {
                var stackLineups = new List<NflLineup>();
                var stackMaxLineups = stack.NumLineups;
                var teams = new List<string>();
                var QB = new PlayerService().GetPlayerById(playerList, stack.QBId);
                var RB1 = new PlayerService().GetPlayerById(playerList, stack.RBId);
                var WR1 = new PlayerService().GetPlayerById(playerList, stack.WR1Id);
                var WR2 = new PlayerService().GetPlayerById(playerList, stack.WR2Id);
                var TE = new PlayerService().GetPlayerById(playerList, stack.TEId);
                var lineupInProgress = new NflLineup(salaryCap);
                lineupInProgress.PlayersList.Add(QB);
                if (RB1 != null)
                    lineupInProgress.PlayersList.Add(RB1);
                if (WR1 != null)
                    lineupInProgress.PlayersList.Add(WR1);
                if (WR2 != null)
                    lineupInProgress.PlayersList.Add(WR2);
                if (TE != null)
                    lineupInProgress.PlayersList.Add(TE);
                foreach (var enabledDST in new PlayerService().GetDSTs(playerList))
                {
                    while (lineupInProgress.PlayersList.Count > 5)
                    {
                        lineupInProgress.Remove(lineupInProgress.PlayersList.Last());
                    }

                    lineupInProgress.Add(enabledDST);
                    var playerPool = playerList.Where(x => x.Opponent != enabledDST.Team && x.Position != "QB" && x.Position != "DST" && !lineupInProgress.PlayersList.Where(x => x.Position != "DST").Select(x => x.Team).Distinct().Contains(x.Team) && !lineupInProgress.PlayersList.Contains(x)).ToList();
                    foreach (var player1 in playerPool.OrderByDescending(x => x.PlayerValue))
                    {
                        while (lineupInProgress.PlayersList.Count > 6)
                        {
                            lineupInProgress.Remove(lineupInProgress.PlayersList.Last());
                        }

                        if (lineupInProgress.CanDraft(player1))
                        {
                            lineupInProgress.Add(player1);
                            if (lineupInProgress.RemainingSalary() >= 5500)
                            {
                                var maxSalaryForPlayer2 = lineupInProgress.RemainingSalary() - 2500;
                                var player2Pool = playerPool.Where(x => x.Salary <= maxSalaryForPlayer2 && !lineupInProgress.PlayersList.Where(x => x.Position != "DST").Select(x => x.Team).Distinct().Contains(x.Team) && !lineupInProgress.PlayersList.Contains(x)).OrderByDescending(x => x.PlayerValue).ToList();
                                foreach (var player2 in player2Pool)
                                {
                                    while (lineupInProgress.PlayersList.Count > 7)
                                    {
                                        lineupInProgress.Remove(lineupInProgress.PlayersList.Last());
                                    }

                                    if (lineupInProgress.CanDraft(player2))
                                    {
                                        lineupInProgress.Add(player2);
                                        if (lineupInProgress.RemainingSalary() >= 2500)
                                        {
                                            var player3Pool = playerPool.Where(x => !lineupInProgress.PlayersList.Contains(x) && x.Salary <= lineupInProgress.RemainingSalary() && !lineupInProgress.PlayersList.Where(x => x.Position != "DST").Select(x => x.Team).Distinct().Contains(x.Team) && lineupInProgress.PositionsAvailable().Contains(x.Position)).OrderByDescending(x => x.PlayerValue).ToList();
                                            foreach (var player3 in player3Pool)
                                            {
                                                while (lineupInProgress.PlayersList.Count > 8)
                                                {
                                                    lineupInProgress.Remove(lineupInProgress.PlayersList.Last());
                                                }

                                                if (lineupInProgress.CanDraft(player3))
                                                {
                                                    lineupInProgress.Add(player3);
                                                    var lineupPlayers = lineupInProgress.ToLineupString();
                                                    if (lineupInProgress.IsValid() && lineupInProgress.RemainingSalary() < 600 && !lineups.Select(x => x.LineupPlayers).Contains(lineupPlayers) && !stackLineups.Select(x => x.LineupPlayers).Contains(lineupPlayers))
                                                    {
                                                        //valid lineup, so add it
                                                        var L = new NflLineup(salaryCap);
                                                        foreach (Player p in lineupInProgress.PlayersList)
                                                        {
                                                            L.Add(p);
                                                        }

                                                        L.ToLineupString();
                                                        stackLineups.Add(L);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                lineups.AddRange(stackLineups.OrderByDescending(x => x.TotalValue).Take(stackMaxLineups));
            }

            //lineups = lineups.Where(x => x.TotalValue > 63).OrderByDescending(x => x.TotalValue).ToList();
            lineups = lineups.OrderByDescending(x => x.TotalValue).ToList();
            lineups = lineups.Take(150).ToList();
            var numlineups = lineups.Count;
            fetching = false;
            StateHasChanged();
        }
    }
}