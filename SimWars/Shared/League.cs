using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models;
public partial class League {
  public int Id { get; set; }
  public string LeagueName { get; set; } = string.Empty;
  public string LeagueSlogan { get; set; } = string.Empty;
  public bool IsPrivate { get; set; }
}
