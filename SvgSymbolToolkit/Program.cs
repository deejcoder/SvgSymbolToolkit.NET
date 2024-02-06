using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.Logging;
using SvgSymbolToolkit.Infrastructure;
using SvgSymbolToolkit.Models;


ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder.ClearProviders()
        .AddConsole();
    builder.SetMinimumLevel(LogLevel.Debug);
});

var parser = new CommandLine.Parser(cfg =>
{
    cfg.HelpWriter = null;
});


// parse the command line arguments into a model
ParserResult<Configuration> parserResult = parser.ParseArguments<Configuration>(Environment.GetCommandLineArgs());

await parserResult.WithParsedAsync(async (Configuration options) =>
{
    // normally services and logging will be part of the dependency injection container
    // however, as this is a simple tool...
    ILogger logger = loggerFactory.CreateLogger<Configuration>();

    try
    {
        logger.LogInformation("Reading file: {SvgFilePath}", options.SvgFilePath);

        // extract the bits we need from the SVG file
        SvgInfo svgInfo = await SvgFileAnalyzer.GetInfo(options.SvgFilePath);

        // generate code based on the SVG file
        CSharpCodeGenerator codeGenerator = new(options);

        await codeGenerator.WriteToFile(svgInfo);

        logger.LogInformation("Generation complete, output: {OutputFilePath}", options.OutputFilePath);
    }
    catch (Exception e)
    {
        logger.LogError("Unexpected error processing file: {Message}", e.Message);
    }
});

parserResult.WithNotParsed(errors =>
{
    // when the tool is given invalid arguments --
    HelpText helpText = HelpText.AutoBuild(parserResult);

    foreach (var error in errors)
    {
        if (error is HelpRequestedError || error is VersionRequestedError)
        {
            Console.WriteLine(helpText);
        }
        else
        {
            Console.Write($"Error processing command: {error}");
        }
    }
});
