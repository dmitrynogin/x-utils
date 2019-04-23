using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace X.Sockets.Json
{
    class JObjectClient : MessageClient<JObject>
    {
        public JObjectClient(IPEndPoint endPoint)
            : this(Connect(endPoint))
        {
        }

        public JObjectClient(TcpClient client)
            : base(client)
        {
            Reader = new StreamReader(Stream);
            Writer = new StreamWriter(Stream);
        }

        TextReader Reader { get; }
        TextWriter Writer { get; }

        protected override void Receive()
        {
            var json = Reader.ReadLine();
            var jObject = JsonConvert.DeserializeObject<JObject>(json);
            Subject.OnNext(jObject);
        }

        public override void Send(JObject message)
        {
            var json = JsonConvert.SerializeObject(message);
            Writer.WriteLine(json);
            Writer.Flush();
        }
    }
}
