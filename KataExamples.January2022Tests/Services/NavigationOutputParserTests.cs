using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace KataExamples.January2022.Services.Tests
{
    public class NavigationOutputParserTests
    {
        Mock<ILineParserService> _mockLineParser = new Mock<ILineParserService>();

        NavigationOutputParser _parser;

        public NavigationOutputParserTests()
        {
            _parser = new NavigationOutputParser(_mockLineParser.Object);
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
        }

        [Fact]
        public async Task ParseNavigationOutputAsyncTest_ArgumentNullException()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _parser.ParseNavigationOutputAsync(null));
        }
    }
}