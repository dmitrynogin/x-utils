using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using System.Text;
using X.Voice.Amazon;

namespace X.Voice
{
    public abstract class Voice : IObservable<string>, IDisposable
    {
        public static Voice Test() => new TestVoice();
        public static Voice Amazon(string username, string password) => new AmazonVoice(username, password);

        protected Subject<string> Subject { get; } = new Subject<string>();

        public virtual void Dispose() => 
            Subject.Dispose();

        public abstract void Say(string text);
        public IDisposable Subscribe(IObserver<string> observer) => 
            Subject.Subscribe(observer);
    }
}
