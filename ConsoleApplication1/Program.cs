using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BufferPlay
{
    class Program
    {
        // instead of this named method, we'll use the anonymos method below.
        /*
        static void ConsoleWrite(double data)
        {
            Console.WriteLine(data);
        }
        */

        static void Main(string[] args)
        {
            // action delegate is built into .NET. 
            // it always returns void, takes 0-16 parameters that you can type.
            // we also replaced its definition with an annonymous method.
            Action<double> print = delegate (double data)
            {
                Console.WriteLine(data);
            };

            var buffer = new Buffer<double>();

            ProcessInput(buffer);

            // don't need consoleOut any more. Can just use the new print method.
            // though in BufferExtenstions will need to change parameter.
            buffer.Dump(print);
             
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
