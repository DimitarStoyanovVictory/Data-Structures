using System;
using System.Linq;

public class RemoveOddOccurences
{
    static void Main()
    {
        var input = Console.ReadLine();
        var intList = input.Split(' ').ToList().ConvertAll(s => int.Parse(s));

        var doubledList = intList.GroupBy(num => num).Where(num => num.Count() % 2 == 0).ToList();

        doubledList.ForEach(collection => collection.ToList().ForEach(num => Console.Write(num + " ")));
    }
}
