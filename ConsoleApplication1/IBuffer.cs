using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    public interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        // this will allow clients to convert the collection into another type.
        // The syntax has us put the variable output type after the method name in <>s.
        IEnumerable<TOutput> AsEnumerableOf<TOutput>();
        T Read();
    }
}
