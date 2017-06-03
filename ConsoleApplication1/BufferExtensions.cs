using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    // this line is no longer needed now that we have Action
    //public delegate void Printer<T>(T data);

    public static class BufferExtensions
    {
       
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
                yield return result;
            }
        }

        // changed Printer<T> to Action<T> so all matches.
        public static void Dump<T>(this IBuffer<T> buffer, Action<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

    }
}
