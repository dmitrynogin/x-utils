using System;
using System.Collections.Generic;
using System.Text;

namespace X.IoC
{
    public abstract class LifetimeScope : IDisposable
    {
        public static readonly LifetimeScope Null = new NullScope();

        public static LifetimeScope Root { get; protected set; } = Null;
        public abstract LifetimeScope BeginScope();
        public abstract void Dispose();
        public T Resolve<T>() => (T)Resolve(typeof(T));
        public abstract object Resolve(Type type);

        class NullScope : LifetimeScope
        {
            public override LifetimeScope BeginScope() => this;
            public override void Dispose() { }
            public override object Resolve(Type type) => null;
        }
    }
}
