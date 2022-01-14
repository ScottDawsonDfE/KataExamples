namespace KataExamples.January2022.Services
{
    public interface ILineParserService
    {
        LineParseResult ParseLine(string line);
    }
    public class LineParserService : ILineParserService
    {
        public LineParseResult ParseLine(string? line)
        {
            if (line is null) throw new ArgumentNullException(nameof(line));
            var openingBrackets = new List<char> { '(', '[', '{', '<' };
            var closingBrackets = new List<char> { ')', ']', '}', '>' };
            var bracketDictionary = new Dictionary<char, char>
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' },
                { '<', '>' },
            };
            var closingBracketScoreDictionary = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 }
            };

            Stack<char> stack = new Stack<char>();

            foreach (var character in line)
            {
                //if open bracket add a child chunk
                if (openingBrackets.Contains(character))
                {
                    stack.Push(character);
                }
                else if (closingBrackets.Contains(character))
                {
                    var lastOpeningBracket = stack.First();
                    var expectedClosingBracket = bracketDictionary.GetValueOrDefault(lastOpeningBracket);
                    if (character == expectedClosingBracket) stack.Pop();
                    else
                    {
                        var score = closingBracketScoreDictionary.GetValueOrDefault(character);
                        return new LineParseResult(line, LineParseOutcome.Corrupted, character, score);
                    }
                }
                else throw new ArgumentOutOfRangeException(nameof(line), $"Character {character} in {line}");
            }

            if (stack.Any()) return new LineParseResult(line, LineParseOutcome.Incomplete, null, 0);

            return new LineParseResult(line, LineParseOutcome.Complete, null, 0);
        }
    }
}
