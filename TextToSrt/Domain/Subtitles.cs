using SubtitlesConverter.Domain.TextProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SubtitlesConverter.Domain
{
    class Subtitles
    {
        private IEnumerable<SubtitleLine> Lines { get; }

        public Subtitles(IEnumerable<SubtitleLine> lines)
        {
            this.Lines = lines.ToList();
        }

        public static Subtitles Parse(string[] text, TimeSpan clipDuration)
        {
            //ITextProcessor pipeline = new Pipeline(
            //    new LinesTrimmer(),
            //    new SentencesBreaker(),
            //    new LinesBreaker(95, 45));

            //ITextProcessor chainedProcessor = new ChainedProcessor(new ChainedProcessor(
            //    new LinesTrimmer(),
            //    new SentencesBreaker()),
            //    new LinesBreaker(95, 45));

            ITextProcessor parsing = new LinesTrimmer()
                .Then(new SentencesBreaker())
                .Then(new LinesBreaker(95, 45));

            IEnumerable<string> lines = parsing.Execute(text);

            TextDurationMeter durationMeter = new TextDurationMeter(lines, clipDuration);
            IEnumerable<SubtitleLine> subtitles = lines
                .Select(line => (text: line, duration: durationMeter.EstimateDuration(line)))
                .Select(tuple => new SubtitleLine(tuple.text, tuple.duration));
            return new Subtitles(subtitles);
        }

        private static IEnumerable<string> BreakIntoSentences(IEnumerable<string> text) =>
            new SentencesBreaker().Execute(text);

        public void SaveAsSrt(FileInfo destination) =>
            File.WriteAllLines(destination.FullName, this.GenerateSrtFileContent());

        private IEnumerable<string> GenerateSrtFileContent() =>
            this.GenerateLineBoundaries()
                .SelectMany((tuple, index) =>
                    new[]
                    {
                        $"{index + 1}",
                        $"{tuple.begin:hh\\:mm\\:ss\\,fff} --> {tuple.end:hh\\:mm\\:ss\\,fff}",
                        $"{tuple.content}",
                        string.Empty
                    });

        private IEnumerable<(TimeSpan begin, TimeSpan end, string content)> GenerateLineBoundaries()
        {
            TimeSpan begin = new TimeSpan(0);
            foreach (SubtitleLine line in this.Lines)
            {
                TimeSpan end = begin + line.Duration;
                yield return (begin, end, line.Content);
                begin = end;
            }
        }
    }
}
