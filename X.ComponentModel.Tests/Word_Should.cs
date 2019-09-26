using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class Word_Should
    {
        [TestMethod]
        public void Normalize()
        {
            var name = new Name(" Thomas ", null, "  Jefferson \n \r ");
            Assert.AreEqual("Thomas", name.First);
            Assert.AreEqual("", name.Middle);
            Assert.AreEqual("Jefferson", name.Last);
        }
    }

    class Name
    {
        public Name(string first, string middle, string last)
            : this((Word)first, (WordOrEmpty)middle, (Word)last)
        {
        }

        public Name(Word first, WordOrEmpty middle, Word last)
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        public Word First { get; }
        public WordOrEmpty Middle { get; }
        public Word Last { get; }
    }
}
