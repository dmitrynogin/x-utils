using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using X.Endpoints.Bitmaps;
using X.Endpoints.Json;

namespace X.Endpoints
{
    public static class EndPoint
    {
        public static IEndPoint<JObject> JObject(this IPEndPoint endPoint, bool listen = false) =>
            listen 
            ? (IEndPoint<JObject>)new JObjectServer(endPoint) 
            : (IEndPoint<JObject>)new JObjectClient(endPoint);

        public static IEndPoint<Bitmap> Bitmap(this IPEndPoint endPoint, bool listen = false) =>
            listen
            ? (IEndPoint<Bitmap>)new BitmapServer(endPoint)
            : (IEndPoint<Bitmap>)new BitmapClient(endPoint);
    }
}
