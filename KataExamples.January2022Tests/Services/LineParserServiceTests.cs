using System;
using Xunit;

namespace KataExamples.January2022.Services.Tests
{
    public class LineParserServiceTests
    {
        LineParserService _lineParserService = new LineParserService();

        public const char curvedBracket = ')';

        [Theory()]
        [InlineData("()", LineParseOutcome.Complete, 0, null)]
        [InlineData("[]", LineParseOutcome.Complete, 0, null)]
        [InlineData("{}", LineParseOutcome.Complete, 0, null)]
        [InlineData("<>", LineParseOutcome.Complete, 0, null)]
        [InlineData("([])", LineParseOutcome.Complete, 0, null)]
        [InlineData("{()()()}", LineParseOutcome.Complete, 0, null)]
        [InlineData("<([{}])>", LineParseOutcome.Complete, 0, null)]
        [InlineData("(){}<>[]()", LineParseOutcome.Complete, 0, null)]
        [InlineData("[<>({}){}[([])<>]]", LineParseOutcome.Complete, 0, null)]
        [InlineData("(((((((((())))))))))", LineParseOutcome.Complete, 0, null)]
        [InlineData("(]", LineParseOutcome.Corrupted, 57, ']')]
        [InlineData("{()()()>", LineParseOutcome.Corrupted, 25137, '>')]
        [InlineData("(((()))}", LineParseOutcome.Corrupted, 1197, '}')]
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>", LineParseOutcome.Corrupted, 1197, '}')]
        [InlineData("[{[{({}]{}}([{[{{{}}([]", LineParseOutcome.Corrupted, 57, ']')]
        [InlineData("<{([([[(<>()){}]>(<<{{", LineParseOutcome.Corrupted, 25137, '>')]
        [InlineData(">", LineParseOutcome.Corrupted, 25137, '>')]
        [InlineData("[({(<(())[]>[[{[]{<()<>>", LineParseOutcome.Incomplete, 0, null)]
        [InlineData("[(()[<>])]({[<{<<[]>>(", LineParseOutcome.Incomplete, 0, null)]
        [InlineData("(((({<>}<{<{<>}{[]{[]{}", LineParseOutcome.Incomplete, 0, null)]
        [InlineData("{<[[]]>}<{[{[{[]{()[[[]", LineParseOutcome.Incomplete, 0, null)]
        [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", LineParseOutcome.Incomplete, 0, null)]
        public void ParseLineTest(string lineToParse, LineParseOutcome expectedOutcome, int expectedScore, char? expectedCorruptionCharacter)
        {
            var result = _lineParserService.ParseLine(lineToParse);

            Assert.Equal(expectedOutcome, result.Outcome);
            Assert.Equal(expectedCorruptionCharacter, result.CorruptionCharacter);
            Assert.Equal(expectedScore, result.Score);
        }

        [Theory]
        [InlineData("<([]){()}[{}])", LineParseOutcome.Corrupted, 3)]
        [InlineData("[[<[([]))<([[{}[[()]]]", LineParseOutcome.Corrupted, 3)]
        [InlineData("[<(<(<(<{}))><([]([]()", LineParseOutcome.Corrupted, 3)]
        public void ParseLineTest_CloseParenthesisExpectedTest(string lineToParse, LineParseOutcome expectedOutcome, int expectedScore)
        {
            var result = _lineParserService.ParseLine(lineToParse);

            Assert.Equal(expectedOutcome, result.Outcome);
            Assert.Equal(')', result.CorruptionCharacter);
            Assert.Equal(expectedScore, result.Score);
        }

        [Fact()]
        public void ParseLineTest_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _lineParserService.ParseLine(null));
        }

        [Fact()]
        public void ParseLineTest_ArgumentNotSupportedException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _lineParserService.ParseLine("((S))"));
        }
    }
}