using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace X.Endpoints
{
    public abstract class MessageServer<T> : IEndPoint<T>
    {
        public MessageServer(IPEndPoint endPoint)
        {
            Listener = new TcpListener(endPoint);
            Listener.Start();

            Clients = new HashSet<MessageClient<T>>();
            Subject = new Subject<T>();
            Task.Run(() => Listen());
        }

        public void Dispose()
        {
            Listener.Stop();
            Subject.Dispose();
            lock (Clients)
                foreach (var client in Clients)
                    client.Dispose();
        }

        TcpListener Listener { get; }
        HashSet<MessageClient<T>> Clients { get; }
        Subject<T> Subject { get; }

        protected abstract MessageClient<T> Connect(TcpClient client);

        public IDisposable Subscribe(IObserver<T> observer) =>
            Subject.Subscribe(observer);

        public void Send(T message)
        {
            lock (Clients)
                foreach (var client in Clients.ToArray())
                    try
                    {
                        client.Send(message);
                    }
                    catch
                    {
                        client.Dispose();
                        Clients.Remove(client);
                    }
        }

        void Listen()
        {
            while (true)
                try
                {
                    var client = Connect(Listener.AcceptTcpClient());
                    client.Subscribe(Subject);
                    lock (Clients)
                        Clients.Add(client);
                }
                catch
                {
                    return;
                }
        }
    }
}
