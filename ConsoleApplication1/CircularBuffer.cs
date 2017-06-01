using System;
using System.Collections.Generic;

namespace BufferPlay
{
  
    // Changeing it so it inherits from Buffer. Properties must match.
    public class CircularBuffer<T> : Buffer<T>
    {
        // old code is wiped out.
        // now it will be a special case of the buffer with fixed size capacity
        int _capacity;
        public CircularBuffer(int capacity = 10)
        {
            _capacity = capacity;
        }

        public override void Write(T value)
        {
            base.Write(value);
            if(_queue.Count > _capacity)
            {
                // just Dequeue. It throws away the oldest item.
                _queue.Dequeue();
            }
        }

        // should all buffers have an IsFull? This one just returns to make happy (?)
        public bool IsFull {  get { return _queue.Count == _capacity; } }
    }
} 