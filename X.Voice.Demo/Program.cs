using System;
using System.Threading;

namespace X.Voice.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var voice = Voice.Test())
            using (voice.Subscribe(Console.WriteLine))
                while (true)
                {
                    Thread.Sleep(1000);
                    voice.Say(".");
                }
        }
    }
}
