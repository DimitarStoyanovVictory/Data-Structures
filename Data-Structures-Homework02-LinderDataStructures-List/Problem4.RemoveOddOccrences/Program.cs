using System;
using System.Linq;

public class RemoveOddOccurences
{
    static void Main()
    {
        var input = Console.ReadLine();
        var intList = input.Split(' ').ToList().ConvertAll(s => Convert.ToInt32(s));

        var sortedList = intList.GroupBy(num => num).Where(num => num.Count() % 2 == 0);

        sortedList.ToList().ForEach(num => Console.WriteLine(num));
    }
}
