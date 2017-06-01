using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    // We're bringing this functionality into an extension method. 
    public static class BufferExtensions
    {
        // because this method is there, there is no T in the class, so define it in the method name.
        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in buffer)
            {
                TOutput result = (TOutput)converter.ConvertTo(item, typeof(TOutput));
                yield return result;
            }
        }

        public static void Dump<T>(this IBuffer<T> buffer)
        {
            foreach (var item in buffer)
            {
                Console.WriteLine(item);
            }
        }

    }
}
