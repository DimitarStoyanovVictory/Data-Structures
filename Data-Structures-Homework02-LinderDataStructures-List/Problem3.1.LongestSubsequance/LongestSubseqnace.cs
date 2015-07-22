using System;
using System.Linq;

public class LongestSubseqnace
{
    static void Main()
    {
        var input = Console.ReadLine(); // 12 2 7 3 3 8
        var intList = input.Split(' ').ToList().ConvertAll(s => Convert.ToInt32(s));

        var groupedList = intList.GroupBy(num => num).ToList();

        int bestCollectionPosition = 0; 
        int bestCollectionNumber = groupedList[0].Key; // we get the first element 12 in this case
        for (int collection = 0; collection < groupedList.Count - 1; collection++)
        {
            if (groupedList[collection].Count() == groupedList[collection + 1].Count())
            {
                if (groupedList[collection + 1].Key < bestCollectionNumber)
                {
                    bestCollectionPosition = collection + 1;
                    bestCollectionNumber = groupedList[collection + 1].Key;
                }
            }
            else if (groupedList[collection].Count() < groupedList[collection + 1].Count())
            {
                bestCollectionPosition = collection + 1;
                bestCollectionNumber = groupedList[collection + 1].Key;
            }
        }

        groupedList[bestCollectionPosition].ToList().ForEach(num => Console.Write(num + " "));
    }
}
