using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace X.ComponentModel
{
    public class Text : String<Text>, IEnumerable<Line>
    {
        public static explicit operator Text(string text) => new Text(text);
        public Text(string text)
            : base(text, EmptyIfNull, Trim)
        {
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Line> GetEnumerator() => Text
            .Split(new[] { "\r\n", "\n\r", "\r", "\n" }, StringSplitOptions.None)
            .Select(l => (Line)l)
            .GetEnumerator();
    }

    public class Line : String<Line>, IEnumerable<Word>
    {
        public static explicit operator Line(string text) => new Line(text);
        public Line(string text) 
            : base(text, EmptyIfNull, Trim, SpaceIfNewLine)
        {
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Word> GetEnumerator() => Text
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l => (Word)l)
            .GetEnumerator();
    }

    public class LineOrNull : String<LineOrNull>, IEnumerable<Word>
    {
        public static explicit operator LineOrNull(string text) => new LineOrNull(text);
        public LineOrNull(string text)
            : base(text, NullIfEmpty, Trim, SpaceIfNewLine)
        {
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<Word> GetEnumerator() => (Text ?? "")
            .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(l => (Word)l)
            .GetEnumerator();
    }

    public class Word : String<Word>
    {
        public static explicit operator Word(string text) => new Word(text);
        public Word(string text)
            : base(text, NotNullOrWhitespace, Trim, NotMultiline, NoSpace)
        {
        }
    }

    public class WordOrNull : String<WordOrNull>
    {
        public static explicit operator WordOrNull(string text) => new WordOrNull(text);
        public WordOrNull(string text)
            : base(text, Trim, NullIfEmpty, NotMultiline, NoSpace)
        {
        }
    }

    public class WordOrEmpty : String<WordOrEmpty>
    {
        public static explicit operator WordOrEmpty(string text) => new WordOrEmpty(text);
        public WordOrEmpty(string text)
            : base(text, Trim, EmptyIfNull, NotMultiline, NoSpace)
        {
        }
    }
}
