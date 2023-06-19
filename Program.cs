using ParseCricsheet.Process;
using System.CommandLine;

var rootCommand = new RootCommand("parse-cricsheet");

var registerOption = new Option<string>("--register", "Path to people.csv");
var zipArgument = new Argument<string>("zip", "Path to cricsheet zip file");
var outputArgument = new Argument<string>("output", "Path to output sqlite file");

rootCommand.AddOption(registerOption);
rootCommand.AddArgument(zipArgument);
rootCommand.AddArgument(outputArgument);

rootCommand.SetHandler(async (registerValue, zipValue, outputValue) => {
    var options = new RunnerOptions {
        RegisterPath = registerValue,
        ZipPath = zipValue,
        OutputPath = outputValue
    };

    await Runner.Run(options);
}, registerOption, zipArgument, outputArgument);

await rootCommand.InvokeAsync(args);