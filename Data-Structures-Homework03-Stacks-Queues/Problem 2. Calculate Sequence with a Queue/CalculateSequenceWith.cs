using System;
using System.Collections.Generic;

public class CalculateSequenceWith
{
    static void Main()
    {
        var startNumber = int.Parse(Console.ReadLine());

        var queue = new Queue<int>();
        queue.Enqueue(startNumber);

        var member = 0;
        int[] startIndex;
        while (true)
        {
            queue.Enqueue(startNumber + 1);

            if (queue.Count == 50)
            {
                break;
            }

            queue.Enqueue((2 * startNumber) + 1);
            queue.Enqueue(startNumber + 2);

            startIndex = queue.ToArray();
            startNumber = startIndex[member + 1];
            member++;
        }

        foreach (var num in queue)
        {
            Console.Write(num + " ");
        }
    }
}
