using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    // defining a delegate for the output portion of Dump()
    public delegate void Printer(object data);

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

        // with teh delegate as a parameter, dump doesn't know what out put there is, it just iterates through the items correctly.
        public static void Dump<T>(this IBuffer<T> buffer, Printer print)
        {
            foreach (var item in buffer)
            {
                print(item);
            }
        }

    }
}
