using SportsSimulator.Shared.Models;

namespace SportsSimulator.Test {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void TestMethod1() {
			var nbaLineup = new NbaLineup(50000);
			var player1 = new Player();
			player1.Position = "PG";
			player1.SitePlayerId = "247000362";
			nbaLineup.Add(player1, 0);
		}
	}
}