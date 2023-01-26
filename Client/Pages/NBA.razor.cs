using SportsSimulator.Shared;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Client.Pages
{
    public partial class NBA
    {
        private bool fetching;
        private readonly int salaryCap = 50000;
        private List<NbaLineup> lineups = new List<NbaLineup>();
        List<Player> playerList = new List<Player>();
        protected override async Task OnInitializedAsync()
        {
            playerList = await new PlayerService().GetPlayerList("NBA");
        }

        public void BuildLineups()
        {
            fetching = true;
            var lineupInProgress = new NbaLineup(salaryCap);
            var topValuePlayers = playerList.Where(x => x.Enabled).OrderByDescending(x => x.PlayerValue).Take(5);
            foreach (var player1 in topValuePlayers)
            {
                lineupInProgress.RemoveToN(0);
                var slotNum1 = lineupInProgress.CanDraft(player1);
                Console.WriteLine("1: Can Draft: " + player1.PlayerName + " : " + slotNum1.ToString() + Environment.NewLine);
                if (slotNum1 > -1)
                {
                    lineupInProgress.Add(player1, slotNum1);
                }

                var poolForSlot2 = lineupInProgress.GetPlayerPool(playerList);
                foreach (var player2 in poolForSlot2)
                {
                    lineupInProgress.RemoveToN(1);
                    var slotNum2 = lineupInProgress.CanDraft(player2);
                    Console.WriteLine("2: Can Draft: " + player2.PlayerName + " : " + slotNum2.ToString() + Environment.NewLine);
                    if (slotNum2 > -1)
                    {
                        lineupInProgress.Add(player2, slotNum2);
                        var poolForSlot3 = lineupInProgress.GetPlayerPool(playerList);
                        foreach (var player3 in poolForSlot3)
                        {
                            lineupInProgress.RemoveToN(2);
                            var slotNum3 = lineupInProgress.CanDraft(player3);
                            Console.WriteLine("3: Can Draft: " + player3.PlayerName + " : " + slotNum3.ToString() + Environment.NewLine);
                            if (slotNum3 > -1)
                            {
                                lineupInProgress.Add(player3, slotNum3);
                                var poolForSlot4 = lineupInProgress.GetPlayerPool(playerList);
                                foreach (var player4 in poolForSlot4)
                                {
                                    lineupInProgress.RemoveToN(3);
                                    var slotNum4 = lineupInProgress.CanDraft(player4);
                                    Console.WriteLine("4: Can Draft: " + player4.PlayerName + " : " + slotNum4.ToString() + Environment.NewLine);
                                    if (slotNum4 > -1)
                                    {
                                        lineupInProgress.Add(player4, slotNum4);
                                        var poolForSlot5 = lineupInProgress.GetPlayerPool(playerList);
                                        foreach (var player5 in poolForSlot5)
                                        {
                                            lineupInProgress.RemoveToN(4);
                                            var slotNum5 = lineupInProgress.CanDraft(player5);
                                            Console.WriteLine("5: Can Draft: " + player5.PlayerName + " : " + slotNum5.ToString() + Environment.NewLine);
                                            if (slotNum5 > -1)
                                            {
                                                lineupInProgress.Add(player5, slotNum5);
                                                var poolForSlot6 = lineupInProgress.GetPlayerPool(playerList);
                                                foreach (var player6 in poolForSlot6)
                                                {
                                                    lineupInProgress.RemoveToN(5);
                                                    var slotNum6 = lineupInProgress.CanDraft(player6);
                                                    Console.WriteLine("6: Can Draft: " + player6.PlayerName + " : " + slotNum6.ToString() + Environment.NewLine);
                                                    if (slotNum6 > -1)
                                                    {
                                                        lineupInProgress.Add(player6, slotNum6);
                                                        var poolForSlot7 = lineupInProgress.GetPlayerPool(playerList);
                                                        foreach (var player7 in poolForSlot7)
                                                        {
                                                            lineupInProgress.RemoveToN(6);
                                                            var slotNum7 = lineupInProgress.CanDraft(player7);
                                                            Console.WriteLine("7: Can Draft: " + player7.PlayerName + " : " + slotNum7.ToString() + Environment.NewLine);
                                                            if (slotNum7 > -1)
                                                            {
                                                                lineupInProgress.Add(player7, slotNum7);
                                                                var poolForSlot8 = lineupInProgress.GetPlayerPool(playerList);
                                                                poolForSlot8 = poolForSlot8.Where(x => x.Salary >= lineupInProgress.RemainingSalary() - 500).ToList();
                                                                foreach (var player8 in poolForSlot8)
                                                                {
                                                                    lineupInProgress.RemoveToN(7);
                                                                    Console.WriteLine(lineupInProgress.LineupPlayers + Environment.NewLine);
                                                                    var slotNum8 = lineupInProgress.CanDraft(player8);
                                                                    Console.WriteLine("8: Can Draft: " + player8.PlayerName + " : " + slotNum8.ToString() + Environment.NewLine);
                                                                    if (slotNum8 > -1)
                                                                    {
                                                                        lineupInProgress.Add(player8, slotNum8);
                                                                        Console.WriteLine(lineupInProgress.LineupPlayers + Environment.NewLine);
                                                                        var lineupPlayers = lineupInProgress.LineupPlayers;
                                                                        if (lineupInProgress.IsValid() && !lineups.Select(x => x.LineupPlayers).Contains(lineupPlayers))
                                                                        {
                                                                            //valid lineup and not a duplicate, so add it				
                                                                            var L = new NbaLineup(salaryCap);
                                                                            var i = 0;
                                                                            foreach (Player p in lineupInProgress.PlayersList.OrderBy(p => p.PlayerNum))
                                                                            {
                                                                                L.Add(p, i);
                                                                                i++;
                                                                            }

                                                                            L.ToLineupString();
                                                                            lineups.Add(L);
                                                                            Console.WriteLine("LINEUP ADDED: " + L.LineupPlayers + Environment.NewLine);
                                                                        }
                                                                    }
                                                                }

                                                                Console.WriteLine("Done looping player 8" + Environment.NewLine);
                                                                Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                                                            }
                                                        }

                                                        Console.WriteLine("Done looping player 7" + Environment.NewLine);
                                                        Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                                                    }
                                                }

                                                Console.WriteLine("Done looping player 6" + Environment.NewLine);
                                                Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                                            }
                                        }

                                        Console.WriteLine("Done looping player 5" + Environment.NewLine);
                                        Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                                    }
                                }

                                Console.WriteLine("Done looping player 4" + Environment.NewLine);
                                Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                            }
                        }

                        Console.WriteLine("Done looping player 3" + Environment.NewLine);
                        Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
                    }
                }

                Console.WriteLine("Done looping player 2" + Environment.NewLine);
                Console.WriteLine("Lineups " + lineups.Count + Environment.NewLine);
            }

            Console.WriteLine("Done");
            //lineups = lineups.Where(x => x.TotalValue > 63).OrderByDescending(x => x.TotalValue).ToList();
            lineups = lineups.Take(100000).ToList();
            var numlineups = lineups.Count;
            fetching = false;
            StateHasChanged();
        }
    }
}