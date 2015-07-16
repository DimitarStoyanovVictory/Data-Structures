using System;
using System.Linq;

public class SumAndAverage
{
    static void Main()
    {
        var input = Console.ReadLine();
        var intList = input.Split(' ').ToList().ConvertAll(s => Convert.ToInt32(s));

        string output = "Sum=" + intList.Sum() + "; Average=" + intList.Average();
        Console.WriteLine(output);
    }
}
