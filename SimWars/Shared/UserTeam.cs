using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models;
public partial class UserTeam {
  public int Id { get; set; }
  public string UserId { get; set; } = string.Empty;
  public int LeagueId { get; set; }
  public string TeamLocation { get; set; } = string.Empty;
  public string TeamName { get; set; } = string.Empty;
  public string PrimaryColor { get; set; } = string.Empty;
  public string SecondaryColor { get; set; } = string.Empty;
  public string LogoFilename { get; set; } = string.Empty;
  public int Wins { get; set; }
  public int Losses { get; set; }
  public int Prestige { get; set; }
  public int Strength { get; set; }
  public bool IsActive { get; set; }
  public DateTime CreatedDate { get; set; }
}
