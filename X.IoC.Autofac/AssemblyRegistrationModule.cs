using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Module = global::Autofac.Module;

namespace X.IoC.Autofac
{
    public class AssemblyRegistrationModule : Module
    {
        public AssemblyRegistrationModule(IEnumerable<Assembly> assemblies)
            : this(assemblies.ToArray())
        {
        }

        public AssemblyRegistrationModule(params Assembly[] assemblies)
        {
            Assemblies = assemblies;
        }

        IEnumerable<Assembly> Assemblies { get; }

        protected override void Load(ContainerBuilder builder)
        {
            foreach (var assembly in Assemblies)
                builder.RegisterAssembly(assembly);
        }
    }
}
