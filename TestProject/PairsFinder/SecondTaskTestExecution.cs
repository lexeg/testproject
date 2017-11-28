using System;
using System.Collections.Generic;

namespace TestProject
{
    public class SecondTaskTestExecution
    {
        public static void SecondTask()
        {
            Console.WriteLine("Задание 2");
            var collection = new List<int> { 5, 9, 3, 2, 4, 1, 4, 1 };
            var sumNumber = 6;
            var pairs = PairsFinder.PairsFinder.FindAllPairs(collection, sumNumber);
            foreach (var pair in pairs)
            {
                Console.WriteLine("pair: {0} and {1}", pair.FirstNumber, pair.SecondNumber);
            }
        }
    }
}
