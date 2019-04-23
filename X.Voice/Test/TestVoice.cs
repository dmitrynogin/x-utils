using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Text;

namespace X.Voice.Amazon
{
    public class TestVoice : Voice
    {
        public TestVoice()
        {
            Observable.Range(0, int.MaxValue, new EventLoopScheduler())
                .Select(i => Console.ReadLine())
                .Subscribe(Subject);
        }

        public override void Say(string text) =>
            Console.WriteLine(text);
    }
}
