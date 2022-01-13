using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataExamples.January2022
{
    public class Chunk
    {
        public Chunk(Chunk? parentChunk)
        {
            ParentChunck = parentChunk;
            ChildChunks = new List<Chunk>();
        }

        public char? OpeningCharacter { get; set; }
        public char? ClosingCharacter { get; set; }

        public IEnumerable<Chunk> ChildChunks { get; set; }
        public Chunk? ParentChunck { get; private set; }

        public bool IsCorrupted
        {
            get
            {
                return OpeningCharacter is not null && ClosingCharacter is not null
                    && OpeningCharacter != ClosingCharacter;
            }
        }
    }

}
