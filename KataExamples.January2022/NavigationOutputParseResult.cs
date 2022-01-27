using System.Text;

namespace KataExamples.January2022
{
    public record NavigationOutputParseResult(string NavigationOutput, IEnumerable<LineParseResult> LineParseResults, int Score)
    {
        protected virtual bool PrintMembers(StringBuilder builder)
        {
            builder.Append($"NavigationOutput = {Environment.NewLine}{NavigationOutput},{Environment.NewLine}");
            builder.Append($"LineParseResults = [{Environment.NewLine}");
            foreach (var lineParseResult in LineParseResults) builder.Append($"{lineParseResult}, {Environment.NewLine}");
            builder.Append($"], Score = {Score}");
            return true;
        }
    }
}
