namespace KataExamples.January2022
{
    public record LineParseResult(string Line, LineParseOutcome Outcome, char? CorruptionCharacter = null, int Score = 0);
}
