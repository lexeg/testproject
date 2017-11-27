using System;
using System.Collections.Generic;
using System.Threading;

namespace TestProject.MultithreadQueue
{
    public class MultithreadQueue<T>
    {
        private readonly object m_LockObj = new object();
        private readonly Queue<T> m_Queue = new Queue<T>();

        public void Push(T element)
        {
            if (element == null) throw new ArgumentNullException(nameof(element));
            lock (m_LockObj)
            {
                m_Queue.Enqueue(element);
                Monitor.Pulse(m_LockObj);
            }
        }

        public T Pop()
        {
            lock (m_LockObj)
            {
                while (m_Queue.Count == 0) Monitor.Wait(m_LockObj);
                return m_Queue.Dequeue();
            }
        }

        public int Count()
        {
            lock (m_LockObj)
            {
                return m_Queue.Count;
            }
        }
    }
}
