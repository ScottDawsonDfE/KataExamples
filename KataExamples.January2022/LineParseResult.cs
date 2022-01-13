namespace KataExamples.January2022
{
    public record LineParseResult(string Line, LineParseOutcome Outcome, IEnumerable<Chunk> Chunks);
}
