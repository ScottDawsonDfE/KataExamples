using Xunit;
using KataExamples.January2022.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services.Tests
{
    public class LineParserServiceTests
    {
        LineParserService _lineParserService = new LineParserService();

        [Theory()]
        [InlineData("()", LineParseOutcome.Complete)]
        [InlineData("[]", LineParseOutcome.Complete)]
        [InlineData("{}", LineParseOutcome.Complete)]
        [InlineData("<>", LineParseOutcome.Complete)]
        [InlineData("([])", LineParseOutcome.Complete)]
        [InlineData("{()()()}", LineParseOutcome.Complete)]
        [InlineData("<([{}])>", LineParseOutcome.Complete)]
        [InlineData("(){}<>[]()", LineParseOutcome.Complete)]
        [InlineData("[<>({}){}[([])<>]]", LineParseOutcome.Complete)]
        [InlineData("(((((((((())))))))))", LineParseOutcome.Complete)]
        [InlineData("(]", LineParseOutcome.Corrupted)]
        [InlineData("{()()()>", LineParseOutcome.Corrupted)]
        [InlineData("(((()))}", LineParseOutcome.Corrupted)]
        [InlineData("<([]){()}[{}])", LineParseOutcome.Corrupted)]
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>", LineParseOutcome.Corrupted)]
        [InlineData("[[<[([]))<([[{}[[()]]]", LineParseOutcome.Corrupted)]
        [InlineData("[{[{({}]{}}([{[{{{}}([]", LineParseOutcome.Corrupted)]
        [InlineData("[<(<(<(<{}))><([]([]()", LineParseOutcome.Corrupted)]
        [InlineData("<{([([[(<>()){}]>(<<{{", LineParseOutcome.Corrupted)]
        [InlineData("[({(<(())[]>[[{[]{<()<>>", LineParseOutcome.Incomplete)]
        [InlineData("[(()[<>])]({[<{<<[]>>(", LineParseOutcome.Incomplete)]
        [InlineData("(((({<>}<{<{<>}{[]{[]{}", LineParseOutcome.Incomplete)]
        [InlineData("{<[[]]>}<{[{[{[]{()[[[]", LineParseOutcome.Incomplete)]
        [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", LineParseOutcome.Incomplete)]
        public void ParseLineTest(string lineToParse, LineParseOutcome expectedOutcome)
        {
            var result = _lineParserService.ParseLine(lineToParse);

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact()]
        public void ParseLineTest_ArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _lineParserService.ParseLine(null));
        }
    }
}