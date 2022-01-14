using System.Text.RegularExpressions;

namespace KataExamples.January2022.Services
{
    public interface INavigationOutputParserService
    {
        Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? navigationOutput);
    }
    public class NavigationOutputParserService : INavigationOutputParserService
    {
        private readonly ILineParserService _lineParserService;

        public NavigationOutputParserService(ILineParserService lineParserService)
        {
            _lineParserService = lineParserService;
        }

        public async Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? navigationOutput)
        {
            if (navigationOutput == null) throw new ArgumentNullException(nameof(navigationOutput));
            var newLineRegex = "\r\n|\r|\n";
            var lines = Regex.Split(navigationOutput, newLineRegex);

            var tasks = new List<Task<LineParseResult>>();

            foreach (var line in lines)
            {
                tasks.Add(Task.Run(() => _lineParserService.ParseLine(line)));
            }

            var lineResults = await Task.WhenAll(tasks);
            var score = (from lineResult in lineResults select lineResult.Score).Sum();

            return new NavigationOutputParseResult(navigationOutput, lineResults, score);
        }
    }
}
