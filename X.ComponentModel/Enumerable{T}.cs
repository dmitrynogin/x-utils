using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace X.ComponentModel
{
    public abstract class Enumerable<T> : IEnumerable<T>
    {
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public abstract IEnumerator<T> GetEnumerator();
    }
}
