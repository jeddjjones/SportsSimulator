using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsSimulator.Shared.Models {
	public partial class Player {
		public int PlayerId { get; set; }
		public int SlateId { get; set; }
		public string Sport { get; set; } = null!;
		public string SitePlayerId { get; set; } = null!;
		public string PlayerName { get; set; } = null!;
		public string Team { get; set; } = null!;
		public string Opponent { get; set; } = null!;
		public string Position { get; set; } = null!;
		public int Salary { get; set; } = 0;
		public decimal FantasyPoints { get; set; }
		public decimal PointsPerSalary { get; set; }
		public decimal PlayerValue { get; set; }
		public bool Enabled { get; set; }
		public string TeamCSS { get; set; } = null!;
		[NotMapped]
		public int PlayerNum { get; set; }
	}


}
