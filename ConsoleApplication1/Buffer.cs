using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    public class Buffer<T> : IBuffer<T>
    {     
        protected Queue<T> _queue = new Queue<T>();

        public virtual bool IsEmpty
        {
            get
            {
                // changed to the following from default
                return _queue.Count == 0;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _queue)
            {
                yield return item;
            }
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }

        public IEnumerable<TOutput> AsEnumerableOf<TOutput>()
        {
            // there is this class that knows how to convert many things.
            // This method gets a converter for whatever the type of T is in use.
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in _queue)
            {
                var result = converter.ConvertTo(item, typeof(TOutput));
                // return the results. 
                // Assume that the converter did its job and typecast it as ConvertTo returns an object.
                yield return (TOutput)result;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
