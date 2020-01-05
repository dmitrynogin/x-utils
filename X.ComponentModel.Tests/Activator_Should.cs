using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace X.ComponentModel.Tests
{
    [TestClass]
    public class Activator_Should
    {
        [TestMethod]
        public void Create_Instance()
        {
            var folder = Activator<IFolder>.CreateInstance(
                "clr://X.ComponentModel.Tests/X.ComponentModel.Tests.DiskFolder?path=\\Windows");

            Assert.IsTrue(folder.Any());
        }
    }

    public interface IFolder : IEnumerable<string>
    {
    }

    public class DiskFolder : ReadOnlyCollection<string>, IFolder
    {
        public DiskFolder(string path)
            : base(Directory.GetFiles(path))
        {
        }
    }
}
