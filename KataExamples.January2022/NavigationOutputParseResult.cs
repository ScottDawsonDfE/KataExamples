namespace KataExamples.January2022
{
    public record NavigationOutputParseResult(string NavigationOutput, IEnumerable<LineParseResult> LineParseResults, int Score);
}
