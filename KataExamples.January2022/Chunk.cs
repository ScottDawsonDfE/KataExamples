using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022
{
    public class Chunk
    {
        public ChunkType ChunkType { get; set; }
        public Chunk? ParentChunk { get; set; }
        public IEnumerable<Chunk>? ChildChunks { get; set; }
        public int? OpeningIndex { get; set; }
        public int? ClosingIndex { get; set; }
    }
}
