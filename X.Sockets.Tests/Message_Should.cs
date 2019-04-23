using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Reactive.Linq;
using System;
using System.Threading;
using System.Drawing;

namespace X.Sockets.Tests
{
    [TestClass]
    public class Message_Should
    {
        //[TestMethod]
        //public void Echo_JObject()
        //{
        //    var ep = new IPEndPoint(IPAddress.Loopback, 10_000);
        //    using (var server = EndPoint.JObject(ep, listen: true))
        //    using (var client = EndPoint.JObject(ep, listen: false))
        //    {
        //        JObject src = JObject.FromObject(new { test = "Test" });
        //        JObject copy = null;
        //        client.Subscribe(j => copy = j);
        //        server.Subscribe(j => server.Send(j));
        //        client.Send(src);
        //        Thread.Sleep(100);

        //        Assert.AreEqual($"{src}", $"{copy}");
        //    }
        //}

        //[TestMethod]
        //public void Echo_Bitmap()
        //{
        //    var ep = new IPEndPoint(IPAddress.Loopback, 10_000);
        //    using (var server = EndPoint.Bitmap(ep, listen: true))
        //    using (var client = EndPoint.Bitmap(ep, listen: false))
        //    {
        //        Bitmap src = new Bitmap(10, 10);
        //        Bitmap copy = null;
        //        client.Subscribe(b => copy = (Bitmap)b.Clone());
        //        server.Subscribe(b => server.Send(b));
        //        client.Send(src);
        //        Thread.Sleep(100);

        //        Assert.AreEqual(src.Size, copy.Size);
        //    }
        //}
    }
}
