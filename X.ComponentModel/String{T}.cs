using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using X.ComponentModel.Converters;
using static System.String;
using static System.Environment;
using System.Runtime.CompilerServices;

namespace X.ComponentModel
{
    [JsonConverter(typeof(StringJsonConverter))]
    public abstract class String<T> : ValueObject<T>
        where T: String<T>
    {
        protected static string Trim(string text) => text?.Trim();
        protected static string EmptyIfNull(string text) => text ?? Empty;
        protected static string Upper(string text) => text?.ToUpper();
        protected static string Lower(string text) => text?.ToLower();
        
        protected static string NotNull(string text) => 
            text == null ? throw new TextException() :
            text;
        protected static string NotNullOrWhitespace(string text) =>
            IsNullOrWhiteSpace(text) ? throw new TextException() :
            text;
        protected static string NotNullOrEmpty(string text) =>
            IsNullOrEmpty(text) ? throw new TextException() : 
            text;
        protected static string NotMultiline(string text) =>
            text == null ? null :
            text.Contains(NewLine) ? throw new TextException() :
            text;

        public static implicit operator string(String<T> s) => s?.Text;

        protected String(string text, params Func<string, string>[] actions) => 
            Text = actions.Aggregate(text, (acc, f) => f(acc));

        public string Text { get; set; }

        public override string ToString() => Text;

        protected override IEnumerable<object> EqualityCheckAttributes => 
            new[] { Text };
    }

    public class TextException : Exception
    {
        public TextException([CallerMemberName] string rule = null)
            : base($"Text must be {rule}.")
        {
        }
    }
}
