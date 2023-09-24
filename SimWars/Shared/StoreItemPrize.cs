using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models;
public partial class StoreItemPrize {
	public int Id { get; set; }
	public int StoreItemId { get; set; }
	public int OddsStart { get; set; }
	public int OddsEnd { get; set; }
	public bool Guarantee { get; set; }
	public string PrizeName { get; set; } = string.Empty;
	public string PrizeDescription { get; set; } = string.Empty;
	public int PrizeType { get; set;}
	public int PrizeAmount { get; set; }
	public string PrizeDisplayContent { get; set; } = string.Empty;	
	public string ImageUrl { get; set; } = string.Empty;
}
