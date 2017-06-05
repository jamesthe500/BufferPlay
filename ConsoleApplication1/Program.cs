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

            // a bit of logic to make things happen.
            // here, we tell it how to convert a double to a datetime. It's a number of days after 1/1/2010
            Converter<double, DateTime> converter = d => new DateTime(2010, 1, 1).AddDays(d);
            // Had to call Map here. Doesn't need the generic types defined any more b/c it sees the converter that's being called and knows that those are teh types we're workign with.
            var asDates = buffer.Map(converter);
            foreach (var date in asDates)
            {
                Console.WriteLine(date);
            }

        
            buffer.Dump(d => Console.WriteLine(d));
             
            ProcessBuffer(buffer);
        }

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
