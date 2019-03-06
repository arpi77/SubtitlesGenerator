using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SubtitlesConverter.Domain.TextProcessing
{
    class ChainedProcessor : ITextProcessor
    {
        public ChainedProcessor(ITextProcessor first, ITextProcessor next)
        {
            First = first;
            Next = next;
        }

        public ITextProcessor First { get; }
        public ITextProcessor Next { get; }

        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            Next.Execute(First.Execute(text));

    }
}
