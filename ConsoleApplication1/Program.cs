using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new Buffer<double>();

            ProcessInput(buffer);

            buffer.Dump();
            
            // This is the test of our converter.
            // it can't handle all type conversions, of course. Datetime e.g.
            var asInts = buffer.AsEnumerableOf<double, int>();

            foreach (var item in asInts)
            {
                Console.WriteLine(item);
            }
            ProcessBuffer(buffer);
        }

        // We are having the program call an implementation so that CircularBuffer can decide what kind of buffer touse?
        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
