using System.Text;

namespace KataExamples.January2022
{
    public record NavigationOutputParseResult(string NavigationOutput, IEnumerable<LineParseResult> LineParseResults, int Score)
    {
        public override string ToString()
        {
            var lineParseResultsString = new StringBuilder();
            foreach (var lineParseResult in LineParseResults)
                lineParseResultsString.AppendLine(lineParseResult.ToString());

            return $"NavigationOutputParseResult {{ NavigationOutput = {Environment.NewLine} " +
                $"{NavigationOutput}, {Environment.NewLine}" +
                $"LineParseResults = [{Environment.NewLine}" +
                $"{lineParseResultsString}], {Environment.NewLine}" +
                $"Score = {Score} }}";
        }
    }
}
