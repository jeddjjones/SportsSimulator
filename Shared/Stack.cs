using System;
using System.Collections.Generic;

namespace SportsSimulator.Shared.Models {
	public partial class Stack {
		public int StackId { get; set; }
		public string Sport { get; set; } = null!;
		public string Team { get; set; } = null!;
		public int NumLineups { get; set; }
		public int QBId { get; set; }
		public int RBId { get; set; }
		public int WR1Id { get; set; }
		public int WR2Id { get; set; }
		public int TEId { get; set; }
		public bool Enabled { get; set; }
	}
}
