using SportsSimulator.Shared.Models;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

public class NflLineup {

	private int _salaryCap;
	private decimal _totalValue;
	public decimal TotalValue {  get { return _totalValue; } }
	private string _lineupPlayers;
	public string LineupPlayers { get { return _lineupPlayers; } }

	private List<Player> _PlayersList;
	public List<Player> PlayersList { get { return _PlayersList; } }
	
	public NflLineup(int salaryCap) {
		_lineupPlayers = string.Empty;
		_totalValue = 0.00m;
		_PlayersList = new List<Player>();
		_salaryCap = salaryCap;
	}

	public void Add(Player player) {
		if (_PlayersList.Count < 9) {
			_PlayersList.Add(player);
		}
	}

	public void Remove(Player player) {
		_PlayersList.Remove(player);
	}

	public int RemainingSalary() {
		return _salaryCap - _PlayersList.Sum(x => x.Salary);
	}

	public bool CanDraft(Player player) {
		var spotsAvailable = 0;
		var playerCount = _PlayersList.Where(x => x.Position == "FLEX" || x.Position == player.Position).Count();
		switch (player.Position) {
			case "RB":
				spotsAvailable = 3 - playerCount;
				break;
			case "WR":
				spotsAvailable = 4 - playerCount;
				break;
			case "TE":
				spotsAvailable = 2 - playerCount;
				break;
			default:
				spotsAvailable = 0;
				break;
		}
		if (spotsAvailable < 1) return false;
		if (RemainingSalary() < player.Salary) return false;
		if (RemainingSalary() / spotsAvailable < 2500) return false;
		return true;
	}

	public string PositionsAvailable() {
		if (_PlayersList.Where(x => x.Position == "RB").Count() < 2) 
			return "RB";
		if (_PlayersList.Where(x => x.Position == "WR").Count() < 3)
			return "WR";
		if (_PlayersList.Where(x => x.Position == "TE").Count() < 1)
			return "TE";
		return "RBWRTE";
	}

	public bool IsValid() {
		if (_PlayersList.Sum(x => x.Salary) > _salaryCap) return false;
		if (_PlayersList.Count != 9) return false;
		return true;
	}

	public string ToLineupString() {
		var retValue = string.Empty;
		_totalValue = 0.00m;
		foreach(Player p in _PlayersList.OrderBy(x => x.SitePlayerId)) {
			retValue += p.SitePlayerId;
			_totalValue += (decimal)p.PlayerValue;
		}
		_lineupPlayers = retValue;
		return retValue;
	}

	public string ToCSV() {
		var flex = string.Empty;
		var retValue = string.Empty;
		retValue += _PlayersList.First(x => x.Position == "QB").PlayerNameWithId + ",";
		var RBs = _PlayersList.Where(x => x.Position == "RB").ToList();
		if (RBs.Count() == 3) {
			flex = RBs[2].PlayerNameWithId;
		}
		retValue += RBs[0].PlayerNameWithId + ",";
		retValue += RBs[1].PlayerNameWithId + ",";
		var WRs = _PlayersList.Where(x => x.Position == "WR").ToList();
		if (WRs.Count() == 4) {
			flex = WRs[3].PlayerNameWithId;
		}
		retValue += WRs[0].PlayerNameWithId + ",";
		retValue += WRs[1].PlayerNameWithId + ",";
		retValue += WRs[2].PlayerNameWithId + ",";
		var TEs = _PlayersList.Where(x => x.Position == "TE").ToList();
		if (TEs.Count() == 2) {
			flex = TEs[1].PlayerNameWithId;
		}
		retValue += TEs[0].PlayerNameWithId + ",";
		retValue += flex + ",";
		retValue += _PlayersList.First(x => x.Position == "DST").PlayerNameWithId;
		return retValue;
	}
}