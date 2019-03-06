namespace SubtitlesConverter.Domain.TextProcessing
{
    static class ChainConstruction
    {
        public static ITextProcessor Then(this ITextProcessor first, ITextProcessor next) =>
            first is DoNothing ? next
            : next is DoNothing ? first
            : new ChainedProcessor(first, next);
    }
}