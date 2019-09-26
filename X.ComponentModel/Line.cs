using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static System.Environment;

namespace X.ComponentModel
{
    public class Line : String<Line>
    {
        public static explicit operator Line(string text) => new Line(text);
        public Line(string text) 
            : base(text, NotNull, Trim, NotMultiline)
        {
        }
    }

    public class LineOrNull : String<LineOrNull>
    {
        public static explicit operator LineOrNull(string text) => new LineOrNull(text);
        public LineOrNull(string text)
            : base(text, Trim, NotMultiline)
        {
        }
    }

    public class LineOrEmpty : String<LineOrEmpty>
    {
        public static explicit operator LineOrEmpty(string text) => new LineOrEmpty(text);
        public LineOrEmpty(string text)
            : base(text, EmptyIfNull, Trim, NotMultiline)
        {
        }
    }

    public class Text : String<Text>, IReadOnlyList<Line>
    {
        public static explicit operator Text(string text) => new Text(text);
        public Text(string text)
            : base(text, EmptyIfNull, Trim)
        {
            Lines = Text
                .Split(new[] { "\r\n", "\n\r", "\r", "\n" }, StringSplitOptions.None)
                .Select(l => (Line)l)
                .ToArray();
        }

        IReadOnlyList<Line> Lines { get; }
        public int Count => Lines.Count;
        public Line this[int index] => Lines[index];
        public IEnumerator<Line> GetEnumerator() => Lines.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Lines.GetEnumerator();
    }
}
