using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services
{
    public interface ILineParserService
    {
        Task<LineParseResult> ParseLineAsync(string line);
    }
    public class LineParserService : ILineParserService
    {
        public async Task<LineParseResult> ParseLineAsync(string? line)
        {
            if (line is null) throw new ArgumentNullException(nameof(line));
            var openingBrackets = new List<char> { '(', '[', '{', '<' };
            var closingBrackets = new List<char> { ')', ']', '}', '>' };

            foreach (var character in line)
            {
                //if open bracket add a child chunk
                if (openingBrackets.Contains(character))
                {

                }
                else if (closingBrackets.Contains(character))
                {
                    //if close bracket close chunk

                    //if open and close dont match raise corruption

                    //score corruption
                }
                else throw new ArgumentOutOfRangeException(nameof(line), $"Character {character} in {line}");
            }

            return new LineParseResult(line, LineParseOutcome.Complete, null);
        }
    }
}
