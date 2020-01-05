using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace X.IoC.Tests
{
    [TestClass]
    public class ServiceLocator_Should
    {
        [TestMethod]
        public void Resolve_Uri()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AutofacServiceProvider>()
                .AsImplementedInterfaces();

            builder.RegisterType<DiskFolder>();
            var container = builder.Build();
            var provider = container.Resolve<IServiceProvider>();
            var folder = provider.GetService<IFolder>(
                "locator://X.IoC.Tests/X.IoC.Tests.DiskFolder?path=\\Windows");

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
