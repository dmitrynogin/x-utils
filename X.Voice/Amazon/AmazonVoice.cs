using System;
using System.Collections.Generic;
using System.Text;

namespace X.Voice.Amazon
{
    public class AmazonVoice : Voice
    {
        public AmazonVoice(string username, string password)
        {
            Username = username;
            Password = password;
        }

        string Username { get; }
        string Password { get; }

        public override void Say(string text)
        {            
        }
    }
}
