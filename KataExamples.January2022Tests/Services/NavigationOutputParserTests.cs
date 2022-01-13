using Xunit;
using KataExamples.January2022.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services.Tests
{
    public class NavigationOutputParserTests
    {
        NavigationOutputParser parser = new NavigationOutputParser();

        [Theory()]
        [MemberData(null, 0)]
        [MemberData("", 1)]
        [MemberData("    ", 1)]
        [MemberData("({<[]>})", 1)]
        [MemberData("({<[)}>]", 1)]
        [MemberData("({<[]>})\r\n({<[]>})", 2)]
        [MemberData("({<[]>})\r({<[]>})", 2)]
        [MemberData("({<[]>})\n({<[]>})", 2)]
        [MemberData("()\n\r()\n\r()\n\r()\n\r()\n\r()", 6)]
        [MemberData("()\n\r()\n\r()\n\r()\n\r()\n\r()\n\r()\n\r()\n\r()\n\r()\n\r()\r\n", 12)]
        public async Task ParseNavigationOutputAsyncTest(string? navOutput, int expectedNumberOfLines)
        {
            var result = await parser.ParseNavigationOutputAsync(navOutput);

            Assert.Equal(expectedNumberOfLines, result.LineParseResults.Count());
        }
    }
}