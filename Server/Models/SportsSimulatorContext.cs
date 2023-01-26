using Microsoft.EntityFrameworkCore;
using SportsSimulator.Server.Controllers;
using SportsSimulator.Shared.Models;

namespace SportsSimulator.Server.Models {
	public partial class SportsSimulatorContext : DbContext {
		public SportsSimulatorContext() {
		}

		public SportsSimulatorContext(DbContextOptions<SportsSimulatorContext> options)
				: base(options) {
		}

		public virtual DbSet<Player> Players { get; set; } = null!;
		public virtual DbSet<Slate> Slates { get; set; } = null!;
		public virtual DbSet<Stack> Stacks { get; set; } = null!;
		public virtual DbSet<NBA_Stack> NBA_Stacks { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.Entity<Player>(entity => {
				entity.ToTable("Player");

				entity.Property(e => e.FantasyPoints)
						.HasColumnType("decimal(5, 2)")
						.HasDefaultValueSql("((0.00))");

				entity.Property(e => e.PlayerName)
						.HasMaxLength(40)
						.HasDefaultValueSql("('')");

				entity.Property(e => e.Position)
						.HasMaxLength(10)
						.HasDefaultValueSql("('')");

				entity.Property(e => e.SitePlayerId)
						.HasMaxLength(40)
						.HasDefaultValueSql("('')");
			});

			modelBuilder.Entity<Slate>(entity => {
				entity.ToTable("Slate");

				entity.Property(e => e.Site)
						.HasMaxLength(20)
						.HasDefaultValueSql("('')");

				entity.Property(e => e.SlateStart)
						.HasColumnType("datetime")
						.HasDefaultValueSql("('1/1/1900')");

				entity.Property(e => e.SlateTitle)
						.HasMaxLength(100)
						.HasDefaultValueSql("('')");

				entity.Property(e => e.Sport)
						.HasMaxLength(20)
						.HasDefaultValueSql("('')");
			});

			modelBuilder.Entity<Stack>(entity => {
				entity.ToTable("Stack");

				entity.Property(e => e.Sport)
						.HasMaxLength(20)
						.HasDefaultValueSql("('')");
			});

			modelBuilder.Entity<NBA_Stack>(entity => {
				entity.ToTable("NBA_Stack");

				
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
