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
        [InlineData("([{<(<{({{}})}>)>}])", LineParseOutcome.Complete)]
        [InlineData("(()()())", LineParseOutcome.Complete)]
        [InlineData("[()<>{<()>}]", LineParseOutcome.Complete)]
        [InlineData("(){}<>[]()", LineParseOutcome.Complete)]
        [InlineData("(}", LineParseOutcome.Corrupted)]
        [InlineData("(>", LineParseOutcome.Corrupted)]
        [InlineData("(]", LineParseOutcome.Corrupted)]
        [InlineData("<)", LineParseOutcome.Corrupted)]
        [InlineData("{)", LineParseOutcome.Corrupted)]
        [InlineData("[)", LineParseOutcome.Corrupted)]
        [InlineData("({<[(([]))>>})", LineParseOutcome.Corrupted)]
        [InlineData("()[]{}<}", LineParseOutcome.Corrupted)]
        //todo incomplete results
        public async Task ParseLineAsyncTest(string lineToParse, LineParseOutcome expectedOutcome)
        {
            var result = await _lineParserService.ParseLineAsync(lineToParse);

            Assert.Equal(expectedOutcome, result.Outcome);
        }

        [Fact()]
        public async Task ParseLineAsyncTest_ArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _lineParserService.ParseLineAsync(null));
        }
    }
}