using System;
using System.Collections.Generic;

public class ReverseNumbersWithStack
{
    static void Main()
    {
        var input = Console.ReadLine();

        if (input == "")
        {
            Console.WriteLine("(empty)");
        }
        else
        {
            string[] arrayInput = input.Split(' ');

            Stack<int> stack = new Stack<int>();
            foreach (var strNum in arrayInput)
            {
                stack.Push(int.Parse(strNum));
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop() + " ");
            }
        }
    }
}
