using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace X.Endpoints.Bitmaps
{
    public class BitmapServer : MessageServer<Bitmap>
    {
        public BitmapServer(IPEndPoint endPoint) 
            : base(endPoint)
        {
        }

        protected override MessageClient<Bitmap> Connect(TcpClient client) => 
            new BitmapClient(client);
    }
}
