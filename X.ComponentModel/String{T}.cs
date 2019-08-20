using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace X.ComponentModel
{
    public class OrdinalIgnoreCase : IEquatable<OrdinalIgnoreCase>
    {
        public static StringComparer Comparer { get; } = StringComparer.OrdinalIgnoreCase;

        public static implicit operator OrdinalIgnoreCase(string s) => new OrdinalIgnoreCase(s);
        public static implicit operator string(OrdinalIgnoreCase s) => s.Text;

        public OrdinalIgnoreCase(string text) => Text = text;
        public string Text { get; }

        public override int GetHashCode() => Comparer.GetHashCode(Text);
        public override bool Equals(object obj) => Equals(obj as OrdinalIgnoreCase);
        public virtual bool Equals(OrdinalIgnoreCase other) => Comparer.Equals(Text, other.Text);

        public static bool operator ==(OrdinalIgnoreCase left, OrdinalIgnoreCase right) =>
            Equals(left, right);

        public static bool operator !=(OrdinalIgnoreCase left, OrdinalIgnoreCase right) =>
            !Equals(left, right);

        public override string ToString() => Text;
    }
}
