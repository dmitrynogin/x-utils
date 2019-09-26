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
    }
}
