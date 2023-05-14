using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimWars.Shared.Models;
public partial class StoreItemPrize {
	public int Id { get; set; }
	public int StoreItemId { get; set; }
	public string ShortName { get; set; } = string.Empty;
	public int Chance { get; set; }
	public int PrizeType { get; set; }
	public int PrizeQuantity { get; set; }
}
