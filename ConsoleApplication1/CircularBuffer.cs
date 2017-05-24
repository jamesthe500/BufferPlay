using System;
using System.Collections.Generic;

namespace BufferPlay
{
    /*
   Adding an interface
     */
     public interface IBuffer<T>
    {
        bool IsEmpty { get; }
        void Write(T value);
        T Read();
    }

    public class Buffer<T> : IBuffer<T>
    {
        // Making this a better base-class
        // Make it protected so it can be accessed
        protected Queue<T> _queue = new Queue<T>();

        // Members are virtual so that derivers can tweak the behavior if needed.
        public virtual bool IsEmpty
        {
            get
            {
                // changed to the following from default
                return _queue.Count == 0;
            }
        }

        public virtual T Read()
        {
            return _queue.Dequeue();
        }

        public virtual void Write(T value)
        {
            _queue.Enqueue(value);
        }
    }

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

        public bool IsFull {  get { return _queue.Count == _capacity; } }
    }
}