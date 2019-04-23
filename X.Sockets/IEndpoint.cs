using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace X.Sockets
{
    public interface IEndPoint<T> : IObservable<T>, IDisposable
    {
        void Send(T message);
    }
}
