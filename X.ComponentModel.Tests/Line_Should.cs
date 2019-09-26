using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class Line_Should
    {
        [TestMethod]
        public void Trim()
        {
            var line = (Line)"\n test\n ";
            Assert.AreEqual("test", line);
        }

        [TestMethod]
        public void Normalize()
        {
            var line = (Line)"line 1\nline 2";
            Assert.AreEqual("line 1 line 2", line);
        }
    }
}
