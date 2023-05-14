using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models; 
public partial class StoreItem {
	public int Id { get; set; }
	public string ShortName { get; set; } = string.Empty;
	public string LongName { get; set; } = string.Empty;
	public string ShortDescription { get; set; } = string.Empty;
	public int Cost { get; set; }
	public int CurrencyType { get; set; }
}
