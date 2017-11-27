using System.Collections.Generic;

namespace TestProject.PairsFinder
{
    public class PairsFinder
    {
        public static IList<PairsOfNumbers> FindAllPairs(IList<int> collectionOfNumbers, int x)
        {
            var listOfPairs = new List<PairsOfNumbers>();
            var usedNumbers = new bool[collectionOfNumbers.Count];
            for (int i = 0; i < collectionOfNumbers.Count - 1; i++)
            {
                if (usedNumbers[i]) continue;
                var secondNumber = x - collectionOfNumbers[i];
                for (int j = i + 1; j < collectionOfNumbers.Count; j++)
                {
                    if (collectionOfNumbers[j] == secondNumber && !usedNumbers[j])
                    {
                        usedNumbers[i] = usedNumbers[j] = true;
                        listOfPairs.Add(new PairsOfNumbers
                        {
                            FirstNumber = collectionOfNumbers[i],
                            SecondNumber = secondNumber
                        });
                        break;
                    }
                }
            }
            return listOfPairs;
        }
    }
}