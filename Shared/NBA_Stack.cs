using System;
using System.Collections.Generic;

namespace SportsSimulator.Shared.Models {
	public partial class NBA_Stack {
		public int NBA_StackId { get; set; }
		public int NumLineups { get; set; }
		public int PG_PlayerId { get; set; }
		public int SG_PlayerId { get; set; }
		public int SF_PlayerId { get; set; }
		public int PF_PlayerId { get; set; }
		public int C_PlayerId { get; set; }
		public int G_PlayerId { get; set; }
		public int F_PlayerId { get; set; }
		public int U_PlayerId { get; set; }
		public bool Enabled { get; set; }
	}
}
