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
        private ILineParserService _lineParserService;

        public NavigationOutputParser(ILineParserService lineParserService)
        {
            _lineParserService = lineParserService;
        }

        public async Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? navigationOutput)
        {
            if (navigationOutput == null) throw new ArgumentNullException(nameof(navigationOutput));

            var lines = Regex.Split(navigationOutput, "\r\n|\r|\n");

            var tasks = new List<Task<LineParseResult>>();

            foreach (var line in lines)
            {
                tasks.Add(_lineParserService.ParseLineAsync(line));
            }

            var lineResults = await Task.WhenAll(tasks);

            return new NavigationOutputParseResult(navigationOutput, lineResults);
        }
    }
}
