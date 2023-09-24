using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models;
public partial class Player {
  public int Id { get; set; }
  public string LastName { get; set; } = string.Empty;
  public string FirstName { get; set; } = string.Empty;
  public string JerseyNum { get; set; } = string.Empty;
  public string Position { get; set; } = string.Empty;
  public string HeightString { get; set; } = string.Empty;
  public int Height { get; set; }
  public int Weight { get; set; }
  public int ThrowPower { get; set; }
  public int ThrowAccuracy { get; set; }
  public int Speed { get; set; }
  public int Strength { get; set; }
  public int Agility { get; set; }
  public int Catching { get; set; }
  public int Blocking { get; set; }
  public int Tackling { get; set; }
  public int Coverage { get; set; }
  public int KickPower { get; set; }
  public int KickAccuracy { get; set; }
  public int Skill1 { get; set; }
  public int Skill1Value { get; set; }
  public int Skill2 { get; set; }
  public int Skill2Value { get; set; }
  public DateTime DraftedDate { get; set; }
  public DateTime RetireDate { get; set; }
  public int UserTeamId { get; set; }
}
