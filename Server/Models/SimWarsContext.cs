using Microsoft.EntityFrameworkCore;
using SimWars.Server.Controllers;
using SimWars.Shared.Models;

namespace SimWars.Server.Models {
	public partial class SimWarsContext : DbContext {
		public SimWarsContext() {
		}

		public SimWarsContext(DbContextOptions<SimWarsContext> options)
				: base(options) {
		}

		public virtual DbSet<StoreItem> StoreItems { get; set; } = null!;
		public virtual DbSet<StoreItemPrize> StoreItemPrizes { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			//modelBuilder.Entity<Player>(entity => {
			//	entity.ToTable("Player");

			//	entity.Property(e => e.FantasyPoints)
			//			.HasColumnType("decimal(5, 2)")
			//			.HasDefaultValueSql("((0.00))");

			//	entity.Property(e => e.PlayerName)
			//			.HasMaxLength(40)
			//			.HasDefaultValueSql("('')");

			//	entity.Property(e => e.Position)
			//			.HasMaxLength(10)
			//			.HasDefaultValueSql("('')");

			//	entity.Property(e => e.SitePlayerId)
			//			.HasMaxLength(40)
			//			.HasDefaultValueSql("('')");
			//});

			//modelBuilder.Entity<Slate>(entity => {
			//	entity.ToTable("Slate");

			//	entity.Property(e => e.Site)
			//			.HasMaxLength(20)
			//			.HasDefaultValueSql("('')");

			//	entity.Property(e => e.SlateStart)
			//			.HasColumnType("datetime")
			//			.HasDefaultValueSql("('1/1/1900')");

			//	entity.Property(e => e.SlateTitle)
			//			.HasMaxLength(100)
			//			.HasDefaultValueSql("('')");

			//	entity.Property(e => e.Sport)
			//			.HasMaxLength(20)
			//			.HasDefaultValueSql("('')");
			//});

			//modelBuilder.Entity<Stack>(entity => {
			//	entity.ToTable("Stack");

			//	entity.Property(e => e.Sport)
			//			.HasMaxLength(20)
			//			.HasDefaultValueSql("('')");
			//});

			//modelBuilder.Entity<NBA_Stack>(entity => {
			//	entity.ToTable("NBA_Stack");

				
			//});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
