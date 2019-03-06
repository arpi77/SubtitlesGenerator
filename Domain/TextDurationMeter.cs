using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SubtitlesConverter.Domain.Models;

namespace SubtitlesConverter.Domain
{
    internal class TextDurationMeter
    {
        public TimedText Text { get; }
        
        internal TextDurationMeter(TimedText text)
        {
            Text = text;
        }

        public IEnumerable<SubtitleLine> MeasureLines() =>
            this.MeasureLines(this.GetFullTextWeight());

        private IEnumerable<SubtitleLine> MeasureLines(double fullTextWeight) =>
            this.Text.Content
                .Select(line => (
                    line: line,
                    relativeWeight: this.CountReadableLetters(line) / fullTextWeight))
                .Select(tuple => (
                    line: tuple.line,
                    milliseconds: this.Text.Duration.TotalMilliseconds * tuple.relativeWeight))
                .Select(tuple => new SubtitleLine(
                    tuple.line,
                    TimeSpan.FromMilliseconds(tuple.milliseconds)));

        private double GetFullTextWeight() =>
            this.Text.Content.Sum(this.CountReadableLetters);

        private int CountReadableLetters(string text) =>
            Regex.Matches(text, @"\w+").Sum(match => match.Value.Length);
    }
}