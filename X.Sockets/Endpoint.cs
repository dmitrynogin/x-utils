using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using X.Sockets.Bitmaps;
using X.Sockets.Json;

namespace X.Sockets
{
    public static class EndPoint
    {
        public static IEndPoint<JObject> JObject(IPEndPoint endPoint, bool listen = false) =>
            listen 
            ? (IEndPoint<JObject>)new JObjectServer(endPoint) 
            : (IEndPoint<JObject>)new JObjectClient(endPoint);

        public static IEndPoint<Bitmap> Bitmap(IPEndPoint endPoint, bool listen = false) =>
            listen
            ? (IEndPoint<Bitmap>)new BitmapServer(endPoint)
            : (IEndPoint<Bitmap>)new BitmapClient(endPoint);
    }
}
