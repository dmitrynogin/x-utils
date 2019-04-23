using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace X.Endpoints.Json
{
    public class JObjectServer : MessageServer<JObject>
    {
        public JObjectServer(IPEndPoint endPoint) 
            : base(endPoint)
        {
        }

        protected override MessageClient<JObject> Connect(TcpClient client) => 
            new JObjectClient(client);
    }
}
