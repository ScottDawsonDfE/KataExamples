var newLine = "\r\n";
Console.ForegroundColor = ConsoleColor.Green;
Console.Write(
    newLine +
    "  ██████   █████ █████       ███████████  " + newLine +
    " ░░██████ ░░███ ░░███       ░░███░░░░░███ " + newLine +
    "  ░███░███ ░███  ░███        ░███    ░███ " + newLine +   
    "  ░███░░███░███  ░███        ░██████████  " + newLine +
    "  ░███ ░░██████  ░███        ░███░░░░░░   " + newLine +
    "  ░███  ░░█████  ░███      █ ░███         " + newLine +
    "  █████  ░░█████ ███████████ █████        " + newLine +
    " ░░░░░    ░░░░░ ░░░░░░░░░░░ ░░░░░         " + newLine +
    "    Navigation      Log        Parser     " + newLine);
Console.ForegroundColor = ConsoleColor.White;

Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Enter Navigation Log Filepath...");

var filepath = Console.ReadLine();

Console.Clear();

if (string.IsNullOrWhiteSpace(filepath)) 
{
    Console.WriteLine("No filepath recognised!");
    Console.WriteLine("Shutting down");
    Console.WriteLine("Press any key...");
    Console.ReadKey();
    Environment.Exit(0);
}

var file = new FileInfo(filepath);
if (!file.Exists)
{
    Console.WriteLine("File not found!");
    Console.WriteLine("Shutting down");
    Console.WriteLine("Press any key...");
    Console.ReadKey();
    Environment.Exit(0);
}

if(file.Extension != ".txt")
{
    Console.WriteLine("Only txt files are accepted!");
    Console.WriteLine("Shutting down");
    Console.WriteLine("Press any key...");
    Console.ReadKey();
    Environment.Exit(0);
}

Console.WriteLine("Reading File...");
Console.WriteLine();

string? log;
using (var streamReader = new StreamReader(filepath))
{
    log = streamReader.ReadToEnd();
    streamReader.Close();
}

var lineParserService = new KataExamples.January2022.Services.LineParserService();
var parser = new KataExamples.January2022.Services.NavigationOutputParserService(lineParserService);

var result = await parser.ParseNavigationOutputAsync(log);

Console.WriteLine();

Console.Write(result.ToString());

Console.WriteLine();
Console.WriteLine("Finished");
Console.ReadKey();





Console.ReadKey();

