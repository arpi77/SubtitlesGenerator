using System;
using System.Collections.Generic;
using System.Text;

namespace SubtitlesConverter.Domain.TextProcessing
{
    class DoNothing : ITextProcessor
    {
        public IEnumerable<string> Execute(IEnumerable<string> text) => 
            text;
    }
}
