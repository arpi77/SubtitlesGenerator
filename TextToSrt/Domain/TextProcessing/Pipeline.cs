using System.Collections.Generic;
using System.Linq;

namespace SubtitlesConverter.Domain.TextProcessing
{
    class Pipeline : ITextProcessor
    {
        public Pipeline(IEnumerable<ITextProcessor> textProcessors)
        {
            TextProcessors = textProcessors;
        }

        public Pipeline(params ITextProcessor[] textProcessors)
            :this((IEnumerable<ITextProcessor>)textProcessors)
        {
            
        }

        public IEnumerable<ITextProcessor> TextProcessors { get; }

        public IEnumerable<string> Execute(IEnumerable<string> text) =>
            TextProcessors.Aggregate(text, (current, processor) => processor.Execute(current));

    }
}
