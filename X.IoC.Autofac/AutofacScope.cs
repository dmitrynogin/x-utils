using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace X.IoC.Autofac
{
    public class AutofacScope : LifetimeScope
    {
        public static void Register(IEnumerable<Assembly> assemblies) =>
            Register(assemblies.ToArray());

        public static void Register(params Assembly[] assemblies) =>
            Register(new AssemblyRegistrationModule(assemblies));

        public static void Register(IEnumerable<Module> modules) =>
            Register(modules.ToArray());

        public static void Register(params Module[] modules)
        {
            var builder = new ContainerBuilder();
            foreach (var module in modules)
                builder.RegisterModule(module);

            Root = new AutofacScope(
                builder.Build().BeginLifetimeScope());
        }

        AutofacScope(ILifetimeScope scope) => Scope = scope;
        ILifetimeScope Scope { get; }
        public override void Dispose() => Scope.Dispose();
        public override LifetimeScope BeginScope() => new AutofacScope(Scope.BeginLifetimeScope());
        public override object Resolve(Type type) => Scope.Resolve(type);
    }
}
