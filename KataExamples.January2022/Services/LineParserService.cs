using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022.Services
{
    public interface ILineParserService
    {
        Task<LineParseResult> ParseLineAsync(string line);
    }
    public class LineParserService : ILineParserService
    {
        public async Task<LineParseResult> ParseLineAsync(string line)
        {
            throw new NotImplementedException();
        }
    }
}
