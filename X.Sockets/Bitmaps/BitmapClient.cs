using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace X.Sockets.Bitmaps
{
    public class BitmapClient : MessageClient<Bitmap>
    {
        public BitmapClient(IPEndPoint endPoint)
            : this(Connect(endPoint))
        {
        }

        public BitmapClient(TcpClient client)
            : base(client)
        {
            Reader = new BinaryReader(Stream);
            Writer = new BinaryWriter(Stream);
        }

        BinaryReader Reader { get; }
        BinaryWriter Writer { get; }

        protected override void Receive()
        {
            using (var stream = new MemoryStream(Reader.ReadBytes(Reader.ReadInt32())))
            using (var bitmap = (Bitmap)Image.FromStream(stream))
                Subject.OnNext(bitmap);
        }

        public override void Send(Bitmap message)
        {
            using (var stream = new MemoryStream())
            {
                message.Save(stream, ImageFormat.Jpeg);
                var array = stream.ToArray();
                Writer.Write(array.Length);
                Writer.Write(array);
                Writer.Flush();
            }
        }
    }
}
