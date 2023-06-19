using Microsoft.EntityFrameworkCore;
using ParseCricsheet.Model;

namespace ParseCricsheet.Process;

public struct RunnerOptions
{
    public string? RegisterPath { get; set; }
    public string ZipPath { get; set; }
    public string OutputPath { get; set; }
}

public static class Runner
{
    public async static Task Run(RunnerOptions options)
    {
        var matchParser = new MatchParser();
        var matches = matchParser.ParseZipAsync(options.ZipPath);

        var contextOptions = new DbContextOptionsBuilder<CricsheetContext>()
            .UseSqlite($"Data Source={options.OutputPath}");

        var context = new CricsheetContext(contextOptions.Options);

        // Delete and recreate the database
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        context.ChangeTracker.AutoDetectChangesEnabled = false;

        if (!string.IsNullOrWhiteSpace(options.RegisterPath)) {
            var players = RegisterParser.Parse(options.RegisterPath);
            await context.AddRangeAsync(players);
        }

        await foreach (var match in matches) {
            var matchWriter = new MatchWriter(match);
            var entities = matchWriter.GetMatchEntities();
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }
    }
}
