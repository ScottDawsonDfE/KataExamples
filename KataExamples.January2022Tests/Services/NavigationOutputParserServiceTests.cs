using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KataExamples.January2022.Services.Tests
{
    public class NavigationOutputParserServiceTests
    {
        Mock<ILineParserService> _mockLineParser = new Mock<ILineParserService>();

        NavigationOutputParserService _parser;

        public NavigationOutputParserServiceTests()
        {
            _parser = new NavigationOutputParserService(_mockLineParser.Object);
            _mockLineParser.Setup(x => x.ParseLine(It.IsAny<string>())).Returns(new LineParseResult("aT", LineParseOutcome.Corrupted, 'T', 10));
        }

        [Theory()]
        [InlineData("", 1)]
        [InlineData("    ", 1)]
        [InlineData("({<[]>})", 1)]
        [InlineData("({<[)}>]", 1)]
        [InlineData("({<[]>})\r\n({<[]>})", 2)]
        [InlineData("({<[]>})\r({<[]>})", 2)]
        [InlineData("({<[]>})\n({<[]>})", 2)]
        [InlineData("()\r\n()\r\n()\r\n()\r\n()\r\n()", 6)]
        [InlineData("()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n()\r\n", 12)]
        public async Task ParseNavigationOutputAsyncTest(string? navOutput, int expectedNumberOfLines)
        {
            var result = await _parser.ParseNavigationOutputAsync(navOutput);

            Assert.Equal(expectedNumberOfLines, result.LineParseResults.Count());
            Assert.Equal(expectedNumberOfLines * 10, result.Score);
        }

        [Fact]
        public async Task ParseNavigationOutputAsyncTest_ArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _parser.ParseNavigationOutputAsync(null));
        }
    }
}