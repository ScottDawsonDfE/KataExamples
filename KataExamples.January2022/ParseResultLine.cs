using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022
{
    public class ParseResultLine
    {
        public string? InitialLine { get; set; }
        public ParseOutcome? ParseOutcome { get; set; }
        public IEnumerable<Chunk>? Chunks { get; set; }
    }
}
