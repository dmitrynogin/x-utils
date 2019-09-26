using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class Text_Should
    {
        [TestMethod]
        public void Split()
        {
            var text = (Text)"\n line 1\nline 2\r\n line 3 \n ";
            Assert.AreEqual("line 1", text[0]);
            Assert.AreEqual("line 2", text[1]);
            Assert.AreEqual("line 3", text[2]);
        }
    }
}
