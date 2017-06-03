using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    // Now we're going generic so the type can be defined by the client. 
    // When it was an object, boxing had to ocurr for it to turn those objects into doubles.
    public delegate void Printer<T>(T data);

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

        // We put Printer<T> in because, we are using T throughout this method definition and we want whatever that type is to be the type that is dumped.
        public static void Dump<T>(this IBuffer<T> buffer, Printer<T> print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

    }
}
