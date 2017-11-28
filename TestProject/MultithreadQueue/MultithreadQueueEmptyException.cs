using System;
using System.Runtime.Serialization;

namespace TestProject.MultithreadQueue
{
    [Serializable]
    internal class MultithreadQueueEmptyException : Exception
    {
        public MultithreadQueueEmptyException() : base("Вставка элементов завершена и очередь пуста")
        {
        }

        public MultithreadQueueEmptyException(string message) : base(message)
        {
        }

        public MultithreadQueueEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MultithreadQueueEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}