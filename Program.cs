using ParseCricsheet.Model.Input;
using ParseCricsheet.Process;
using System.Text.Json;
using System.Text.Json.Serialization;
using ParseCricsheet.Model;
using Microsoft.EntityFrameworkCore;

// Check args
if (args.Length != 2) {
    Console.WriteLine("Usage: ParseCricsheet <path to ZIP archive> <path to output database>");
    return;
}

var zipPath = args[0];
var outputPath = args[1];

var matchParser = new MatchParser();

var matches = matchParser.ParseZipAsync(zipPath);

var contextOptions = new DbContextOptionsBuilder<CricsheetContext>()
    .UseSqlite($"Data Source={outputPath}");

var context = new CricsheetContext(contextOptions.Options);

// Delete and recreate the database
await context.Database.EnsureDeletedAsync();
await context.Database.EnsureCreatedAsync();

await foreach (var match in matches) {
    var matchWriter = new MatchWriter(match);
    var entities = matchWriter.GetMatchEntities();
    foreach(var entity in entities) {
        await context.AddAsync(entity);
    }
    await context.SaveChangesAsync();
}
