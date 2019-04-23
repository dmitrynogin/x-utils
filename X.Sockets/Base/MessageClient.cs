using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace X.Sockets
{
    public abstract class MessageClient<T> : IEndPoint<T>
    {
        protected static TcpClient Connect(IPEndPoint endPoint)
        {
            var client = new TcpClient();
            client.Connect(endPoint);
            return client;
        }

        protected MessageClient(TcpClient client)
        {
            Client = client;
            Subject = new Subject<T>();
            Stream = Client.GetStream();
            Task.Run(() => Rx());
        }

        TcpClient Client { get; }
        protected Subject<T> Subject { get; }
        protected Stream Stream { get; }

        public void Dispose()
        {
            Client.Dispose();
            Subject.Dispose();
        }

        public IDisposable Subscribe(IObserver<T> observer) =>
            Subject.Subscribe(observer);

        protected abstract void Receive();
        public abstract void Send(T message);
        
        void Rx()
        {
            try
            {
                while (true)
                    Receive();
            }
            catch
            {
                Subject.OnCompleted();
                Dispose();
            }
        }
    }
}
