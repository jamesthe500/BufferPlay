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
            // Switching to Circular to demonstrate event raising with generics.
            var buffer = new CircularBuffer<double>(capacity:3);

            // Created handler below by hitting tab twice after "+="
            // This is where the event is raised
            buffer.ItemDiscarded += Buffer_ItemDiscarded;

            ProcessInput(buffer);
        
            buffer.Dump(d => Console.WriteLine(d));
             
            ProcessBuffer(buffer);
        }

        // The event is handeled here.
        // (Auto gnereated abvoe)
        // writes the line using the info provided by CircularBuffer
        private static void Buffer_ItemDiscarded(object sender, ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full, discarded {0}. New item is {1}", e.ItemDiscarded, e.NewItem);
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
