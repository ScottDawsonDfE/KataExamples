using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services
{
    public interface INavigationOutputParserService
    {
        Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? navigationOutput);
    }
    public class NavigationOutputParser : INavigationOutputParserService
    {
        private readonly ILineParserService _lineParserService;

        public NavigationOutputParser(ILineParserService lineParserService)
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
                
                tasks.Add(Task.Run(() =>  _lineParserService.ParseLine(line)));
            }

            var lineResults = await Task.WhenAll(tasks);

            return new NavigationOutputParseResult(navigationOutput, lineResults);
        }
    }
}
