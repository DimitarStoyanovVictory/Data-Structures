using System;
using System.Collections.Generic;
using System.Linq;

public class LongestSubseqnace
{
    private static void Main()
    {
        var input = Console.ReadLine();
        var intList = input.Split(' ').ToList().ConvertAll(s => Convert.ToInt32(s));

        var helpParameters = new Dictionary<string, int>()
        {
            {"Equal elements", 1},
            {"Current number", 0},
            {"Input element length", intList.Count - 1}
        };

        var output = new Dictionary<string, int>()
        {
            {"Maximum sequance number", 0},
            {"Maximum sequance length", 0}
        };

        for (int index = 0; index < intList.Count; index++)
        {
            if (intList.Count == 1)
            {
                output["Maximum sequance number"] = intList[0];
            }
            else
            {
                helpParameters["Equal elements"] = 1;
                helpParameters["Current number"] = index;

                output = CheckForEqualElements(helpParameters, output, intList, index);
            }
        }

        if (output["Maximum sequance length"] == 0)
        {
            intList.Sort();
            output["Maximum sequance number"] = intList[0];
            output["Maximum sequance length"] = 1;
        }

        PrintResult(output);
    }

    private static void PrintResult(Dictionary<string, int> output)
    {
        for (int index = 0; index < output["Maximum sequance length"]; index++)
        {
            Console.Write(output["Maximum sequance number"] + " ");
        }
    }

    private static Dictionary<string, int> CheckForEqualElements(Dictionary<string, int> helpParameters, Dictionary<string, int> output, List<int> intList, int index)
    {
        while (index < helpParameters["Input element length"])
        {
            if (intList[index] == intList[index + 1])
            {
                helpParameters["Equal elements"]++;

                if (helpParameters["Equal elements"] == output["Maximum sequance length"] && intList[index] < output["Maximum sequance number"])
                {
                    output["Maximum sequance number"] = intList[index];
                }
                else if (helpParameters["Equal elements"] > output["Maximum sequance length"])
                {
                    output["Maximum sequance number"] = intList[index];
                    output["Maximum sequance length"] = helpParameters["Equal elements"];
                }
            }
            else
            {
                break;
            }

            index++;
        }

        return output;
    }
}
