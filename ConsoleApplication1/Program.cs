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
            // Lamda Expression!
            // "given a var d, typed as double, d goes to cw d."
            Action<bool> print = d => Console.WriteLine(d);
            // funcs always take at least one parameter, and the last parameter taken is the return type.
            Func<double, double> square = d => d * d;
            Func<double, double, double> add = (x, y) => x + y;
            // predicates always return a bool
            Predicate<double> isLessThanTen = d => d < 10;

            print(isLessThanTen(square(add(3, 5))));

            var buffer = new Buffer<double>();

            ProcessInput(buffer);
            
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
