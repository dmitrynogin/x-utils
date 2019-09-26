using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class Text_Should
    {
        [TestMethod]
        public void Split()
        {
            var text = (Text)"\n line 1\nline 2\r\n line 3 \n ";

            Assert.AreEqual("line 1", text.ElementAt(0));
            Assert.AreEqual("line 2", text.ElementAt(1));
            Assert.AreEqual("line 3", text.ElementAt(2));

            Assert.AreEqual("line", text.ElementAt(0).ElementAt(0));
            Assert.AreEqual("1", text.ElementAt(0).ElementAt(1));
        }
    }
}
