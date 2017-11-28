using System;
using System.Threading;
using System.Threading.Tasks;
using TestProject.MultithreadQueue;

namespace TestProject
{
    public class FirstTaskTestExecution
    {
        public static void FirstTask()
        {
            Console.WriteLine("Задание 1");
            var queue = new MultithreadQueue<int>();
            StartConcurrentQueue(queue, 15, 10);
        }

        private static void StartConcurrentQueue(MultithreadQueue<int> queue, int pushThreadCount, int popThreadCount)
        {
            var random = new Random();
            var maxRand = 100;
            var pushTasks = new Task[pushThreadCount];
            var popTasks = new Task[popThreadCount];
            for (int i = 0; i < pushThreadCount; i++)
            {
                pushTasks[i] = new Task(() => PushQueue(queue, random, maxRand));
            }
            for (int i = 0; i < popThreadCount; i++)
            {
                popTasks[i] = new Task(() => PopQueue(queue));
            }
            foreach (var task in popTasks)
            {
                task.Start();
            }
            foreach (var task in pushTasks)
            {
                task.Start();
            }
            Task.WaitAll(pushTasks);
            queue.PushFinished();
            Task.WaitAll(popTasks);
            Console.WriteLine($"Проверка очереди: {queue.Count()}");
        }

        private static void PushQueue(MultithreadQueue<int> queue, Random random, int maxRand)
        {
            var value = random.Next(maxRand);
            Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} добавил в очередь элемент со значением {value}");
            queue.Push(value);
        }

        private static void PopQueue(MultithreadQueue<int> queue)
        {
            while (true)
            {
                try
                {
                    var value = queue.Pop();
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId} получил из очереди элемент со значением {value}");
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Поток {Thread.CurrentThread.ManagedThreadId}: {exception.Message}");
                    break;
                }
            }
        }
    }
}
