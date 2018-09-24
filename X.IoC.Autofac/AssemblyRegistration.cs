using Autofac;
using System;
using System.Reflection;

namespace X.IoC.Autofac
{
    static class AssemblyRegistration
    {
        public static ContainerBuilder RegisterAssemblyOf<TAnchor>(this ContainerBuilder builder) =>
            builder.RegisterAssembly(typeof(TAnchor).GetTypeInfo().Assembly);

        public static ContainerBuilder RegisterAssembly(this ContainerBuilder builder, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
                builder.RegisterService(type);

            return builder;
        }

        static void RegisterService(this ContainerBuilder builder, Type type)
        {
            var info = type.GetTypeInfo();
            if (!info.IsClass)
                return;

            if (info.IsAbstract)
                return;

            if (!info.IsDefined(typeof(ServiceAttribute)))
                return;

            var service = info.GetCustomAttribute<ServiceAttribute>();
            var generic = info.IsGenericType;
            if (generic)
            {
                switch (service)
                {
                    case SingletonAttribute _:
                        if (service.AsSelf)
                            builder.RegisterGeneric(type).AsSelf().SingleInstance();
                        else
                            builder.RegisterGeneric(type).AsImplementedInterfaces().SingleInstance();
                        break;

                    case TransientAttribute _:
                        if (service.AsSelf)
                            builder.RegisterGeneric(type).AsSelf().InstancePerDependency();
                        else
                            builder.RegisterGeneric(type).AsImplementedInterfaces().InstancePerDependency();
                        break;

                    case ServiceAttribute _:
                        if (service.AsSelf)
                            builder.RegisterGeneric(type).AsSelf().InstancePerLifetimeScope();
                        else
                            builder.RegisterGeneric(type).AsImplementedInterfaces().InstancePerLifetimeScope();
                        break;
                }
            }
            else
            {
                switch (service)
                {
                    case SingletonAttribute _:
                        if (service.AsSelf)
                            builder.RegisterType(type).AsSelf().SingleInstance();
                        else
                            builder.RegisterType(type).AsImplementedInterfaces().SingleInstance();
                        break;

                    case TransientAttribute _:
                        if (service.AsSelf)
                            builder.RegisterType(type).AsSelf().InstancePerDependency();
                        else
                            builder.RegisterType(type).AsImplementedInterfaces().InstancePerDependency();
                        break;

                    case ServiceAttribute _:
                        if (service.AsSelf)
                            builder.RegisterType(type).AsSelf().InstancePerLifetimeScope();
                        else
                            builder.RegisterType(type).AsImplementedInterfaces().InstancePerLifetimeScope();
                        break;
                }
            }
        }
    }
}
