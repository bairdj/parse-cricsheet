using Microsoft.EntityFrameworkCore;
using ParseCricsheet.Model.Input;

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
        modelBuilder.Entity<Output.Delivery>(a => {
            a.Property(b => b.Bowler).HasConversion<string>(
                p => p.Id,
                p => new PlayerId(p)
            );
            a.Property(b => b.Batter).HasConversion<string>(
                p => p.Id,
                p => new PlayerId(p)
            );
            a.Property(b => b.NonStriker).HasConversion<string>(
                p => p.Id,
                p => new PlayerId(p)
            );
            a.HasKey(b => new { b.MatchId, b.InningsNumber, b.Over, b.Ball });
        });
        modelBuilder.Entity<Output.Wicket>(a => {
            a.HasKey(b => new { b.MatchId, b.InningsNumber, b.Over, b.Ball });
            a.Property(b => b.Batter).HasConversion<string>(
                p => p.Id,
                p => new PlayerId(p)
            );
            a.Property(b => b.Bowler).HasConversion<string>(
                p => p.Id,
                p => new PlayerId(p)
            );
        });
    }

}