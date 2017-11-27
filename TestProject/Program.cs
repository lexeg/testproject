using System;
using System.Collections.Generic;
using System.Threading;
using TestProject.MultithreadQueue;

namespace TestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            FirstTask();
            SecondTask();
            Console.ReadLine();
        }

        private static void FirstTask()
        {
            var queue = new MultithreadQueue<int>();
            StartConcurrentQueue(queue, 15);
            PrintQueue(queue);
        }

        private static void SecondTask()
        {
            var collection = new List<int> { 5, 9, 3, 2, 4, 1, 4, 1 };
            var sumNumber = 6;
            //var collection = new List<int> { 1, 1, 2, 1, 1, 0, 1 };
            //var sumNumber = 2;
            var pairs = PairsFinder.PairsFinder.FindAllPairs(collection, sumNumber);
            foreach (var pair in pairs)
            {
                Console.WriteLine("pair: {0} and {1}", pair.FirstNumber, pair.SecondNumber);
            }
        }

        private static void StartConcurrentQueue(MultithreadQueue<int> queue, int threadCount)
        {
            var threads = new Thread[threadCount];
            WaitHandle[] handles = new WaitHandle[threadCount];
            for (int i = 0; i < threadCount; i++)
            {
                var i1 = i;
                handles[i] = new ManualResetEvent(false);
                threads[i] = new Thread(() =>
                {
                    queue.Push(i1);
                    ((ManualResetEvent)handles[i1]).Set();
                });
                threads[i].Start();
            }
            WaitHandle.WaitAll(handles);
        }

        private static void PrintQueue(MultithreadQueue<int> queue)
        {
            while (queue.Count() != 0)
            {
                var element = queue.Pop();
                Console.WriteLine(element);
            }
        }
    }
}
