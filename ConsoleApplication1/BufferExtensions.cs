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
       // changing around this method. 
       // Name to Map as we are now going to be mapping each input type to its new type.
       // will need a converter passed to it with two inputs.
       // T is the type of the buffer. TToutput is type we already have in place. 
        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> buffer, Converter<T, TOutput> converter)
        {
            // This is a simplter way to write it.
            // This LINQ Select operator is doing a projection. 
            // For each item in buffer, i, run the covnerter and transfomr the i to anothe type.
            return buffer.Select(i => converter(i));
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
