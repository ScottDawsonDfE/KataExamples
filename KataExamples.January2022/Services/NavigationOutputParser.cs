using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services
{
    public interface INavigationOutputParser
    {
        Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? NavigationOutput);
    }
    public class NavigationOutputParser : INavigationOutputParser
    {
        public async Task<NavigationOutputParseResult> ParseNavigationOutputAsync(string? NavigationOutput)
        {
            throw new NotImplementedException();
        }
    }
}
