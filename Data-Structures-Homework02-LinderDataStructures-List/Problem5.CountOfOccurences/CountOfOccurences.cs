using System;
using System.Linq;

public class CountOfOccurences
{
    static void Main()
    {
        var input = Console.ReadLine();
        var intList = input.Split(' ').ToList().ConvertAll(s => int.Parse(s));

        intList.Sort();
        var doubledList = intList.GroupBy(num => num).ToList();

        doubledList.ForEach(collection => Console.WriteLine(collection.Key + " -> " + collection.Count() + " times" ));
    }
}
