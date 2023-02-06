using SportsSimulator.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

public class NbaLineup {
	private int _salaryCap;
	private decimal _totalValue;
	public decimal TotalValue { get { return _totalValue; } }
	private decimal _totalPoints;
	public decimal TotalPoints { get { return _totalPoints; } }
	private string _lineupPlayers;
	public string LineupPlayers { get { return _lineupPlayers; } }

	private List<Player> _PlayersList;
	public List<Player> PlayersList { get { return _PlayersList; } }
	public int SpotsAvailable => _PlayersList.Where(x => string.IsNullOrEmpty(x.SitePlayerId)).Count();

	public NbaLineup(int salaryCap) {
		_salaryCap = salaryCap;
		_PlayersList = new List<Player>();
		for (int i = 0; i < 8; i++) {
			var player = new Player();
			player.PlayerNum = -1;
			_PlayersList.Add(player);
		}
		_lineupPlayers = ToLineupString();
	}

	public void Add(Player player, int lineupSlotIndex) {
		player.PlayerNum = _PlayersList.OrderByDescending(x => x.PlayerNum).Take(1).First().PlayerNum + 1;
		_PlayersList[lineupSlotIndex] = player;
		_lineupPlayers = ToLineupString();
	}

	public void RemoveToN(int n) {
		for (int i = 7; i >= 0; i--) {
			if (_PlayersList[i].PlayerNum >= n) {
				Console.Write("Removing: " + _PlayersList[i].PlayerNameWithId + " from spot " + i.ToString() + Environment.NewLine);
				var player = new Player();
				player.PlayerNum = -1;
				_PlayersList[i] = player;
			}
		}
		_lineupPlayers = ToLineupString();
	}

	public int RemainingSalary() {
		return _salaryCap - _PlayersList.Sum(x => x.Salary);
	}

	public int CanDraft(Player player) {
		if (SpotsAvailable < 1)
			return -1;
		if (RemainingSalary() < player.Salary)
			return -1;
		if (RemainingSalary() / SpotsAvailable < 3000)
			return -1;
		var positions = player.Position.Split("/");
		foreach (var position in positions) {
			switch (position) {
				case "PG":
					if (string.IsNullOrEmpty(_PlayersList[0].SitePlayerId))
						return 0;
					if (string.IsNullOrEmpty(_PlayersList[5].SitePlayerId))
						return 5;
					break;
				case "SG":
					if (string.IsNullOrEmpty(_PlayersList[1].SitePlayerId))
						return 1;
					if (string.IsNullOrEmpty(_PlayersList[5].SitePlayerId))
						return 5;
					break;
				case "SF":
					if (string.IsNullOrEmpty(_PlayersList[2].SitePlayerId))
						return 2;
					if (string.IsNullOrEmpty(_PlayersList[6].SitePlayerId))
						return 6;
					break;
				case "PF":
					if (string.IsNullOrEmpty(_PlayersList[3].SitePlayerId))
						return 3;
					if (string.IsNullOrEmpty(_PlayersList[6].SitePlayerId))
						return 6;
					break;
				case "C":
					if (string.IsNullOrEmpty(_PlayersList[4].SitePlayerId))
						return 4;
					break;
				default:
					return -1;
			}
		}
		if (string.IsNullOrEmpty(_PlayersList[7].SitePlayerId)) {
			return 7;
		} else {
			return -1;
		}
	}

	public List<Player> GetPlayerPool(List<Player> currentPlayerPool) {
		if (currentPlayerPool == null) return new List<Player>();

		var neededAfterAdd = 3000 * (SpotsAvailable - 1);
		var maxAllowedSalary = SpotsAvailable == 1 ? RemainingSalary() : RemainingSalary() - neededAfterAdd;
		var playerPool = currentPlayerPool.Where(x => !_PlayersList.Contains(x) &&
																									x.Salary <= maxAllowedSalary);
		//START - Comment out to allow more than 2 players per team
		Dictionary<string, int> teams = new Dictionary<string, int>();
		var teamsWithPlayerCount = _PlayersList.Where(x => !string.IsNullOrEmpty(x.SitePlayerId))
																	  			 .GroupBy(x => x.Team)
																					 .Select(x => new { Team = x.Key, Count = x.Count() }).ToList();
		foreach(var item in teamsWithPlayerCount) {
			var test1 = item.Team;
			var test2 = item.Count;
		}
		if (teamsWithPlayerCount.Where(x => x.Count > 1).Count() >= 2) {
			// if multiple teams have 2 players, then need to draft from other teams
			playerPool = playerPool.Where(x => !teamsWithPlayerCount.Select(x => x.Team).Contains(x.Team));
		} else {
			// if there are not multiple teams with 2 players 
			playerPool = playerPool.Where(x => !teamsWithPlayerCount.Where(x => x.Count > 1).Select(x => x.Team).Contains(x.Team));
		}
		//END - Comment out to allow more than 2 players per team

		var noGuards = false;		
		if (!string.IsNullOrEmpty(_PlayersList[0].SitePlayerId) && 
			  !string.IsNullOrEmpty(_PlayersList[1].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[5].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[7].SitePlayerId)) {
			noGuards = true;
			playerPool = playerPool.Where(x => x.Position != "PG" && x.Position != "SG" && x.Position != "PG/SG");
		}
		var noForwards = false;
		if (!string.IsNullOrEmpty(_PlayersList[2].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[3].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[6].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[7].SitePlayerId)) {
			noForwards = true;
			playerPool = playerPool.Where(x => x.Position != "SF" && x.Position != "PF" && x.Position != "SF/PF");
		}
		if (noGuards && noForwards) {
			playerPool = playerPool.Where(x => x.Position != "SG/SF" && x.Position != "PG/SF");
		}
		if (!string.IsNullOrEmpty(_PlayersList[4].SitePlayerId) &&
				!string.IsNullOrEmpty(_PlayersList[7].SitePlayerId)) {
			playerPool = playerPool.Where(x => x.Position != "C");
		}

		return playerPool.OrderByDescending(x => x.PlayerValue).ToList();
	}

	public string PositionsAvailable() {
		//TODO: Needs Fixed
		if (string.IsNullOrEmpty(_PlayersList[7].SitePlayerId)) {
			return "PGSGSFPFC";
		}
		var retVal = string.Empty;
		if (string.IsNullOrEmpty(_PlayersList[0].Position) || string.IsNullOrEmpty(_PlayersList[4].Position)) {
			retVal += "PG";
		}
		return "RBWRTE";
	}

	public bool IsValid() {
		if (_PlayersList.Sum(x => x.Salary) > _salaryCap)
			return false;
		if (_PlayersList.Count != 8)
			return false;
		return true;
	}

	public string ToLineupString() {
		var retValue = string.Empty;
		_totalPoints = 0.00m;
		_totalValue = 0.00m;
		foreach (Player p in _PlayersList.OrderBy(x => x.SitePlayerId)) {
			retValue += p.SitePlayerId;
			_totalPoints += (decimal)p.FantasyPoints;
			_totalValue += (decimal)p.PlayerValue;
		}
		_lineupPlayers = retValue;
		return retValue;
	}

	public string ToCSV() {
		return String.Join(',', _PlayersList.Select(x => x.PlayerNameWithId).ToArray());
	}

}
