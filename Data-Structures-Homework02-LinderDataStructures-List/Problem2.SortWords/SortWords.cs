using System;
using System.Linq;

public class SortWords
{
    static void Main()
    {
        var input = Console.ReadLine();
        var stringList = input.Split(' ').ToList();
            
        stringList.Sort();
        stringList.ForEach(str => Console.Write(str + ' '));
        Console.WriteLine();
    }
}
