using Microsoft.EntityFrameworkCore;
using ParseCricsheet.Model.Input;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ParseCricsheet.Model;

public class CricsheetContext : DbContext {

    public CricsheetContext(DbContextOptions<CricsheetContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Output.Match>();
        modelBuilder.Entity<Output.Innings>(a => {
            a.HasKey(b => new { b.MatchId, b.InningsNumber });
            a.HasOne(b => b.Match).WithMany(c => c.Innings).HasForeignKey(d => d.MatchId);
        });

        var playerIdConverter = new ValueConverter<PlayerId, string>(
            p => p.Id,
            p => new PlayerId(p)
        );

        modelBuilder.Entity<Output.Delivery>(a => {
            a.Property(b => b.Bowler).HasConversion<string>(playerIdConverter);
            a.Property(b => b.Batter).HasConversion<string>(playerIdConverter);
            a.Property(b => b.NonStriker).HasConversion<string>(playerIdConverter);
            a.HasKey(b => new { b.MatchId, b.InningsNumber, b.Over, b.Ball });
        });
        modelBuilder.Entity<Output.Wicket>(a => {
            a.HasKey(b => new { b.MatchId, b.InningsNumber, b.Over, b.Ball, b.WicketNumber });
            a.Property(b => b.Batter).HasConversion<string>(playerIdConverter);
            a.Property(b => b.Bowler).HasConversion<string>(playerIdConverter);
        });
        modelBuilder.Entity<Output.Player>(a => {
            a.HasKey(b => b.PlayerId);
            a.Property(b => b.PlayerId).HasConversion<string>(playerIdConverter);
        });
        modelBuilder.Entity<Output.Official>(a => {
            a.HasDiscriminator<string>("OfficialType")
                .HasValue<Output.MatchReferee>("MatchReferee")
                .HasValue<Output.ReserveUmpire>("ReserveUmpire")
                .HasValue<Output.TvUmpire>("TvUmpire")
                .HasValue<Output.Umpire>("Umpire");

            a.HasKey(b => new { b.Id });
        });
    }

}