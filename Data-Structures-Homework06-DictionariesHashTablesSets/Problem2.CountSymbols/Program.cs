using System;
using System.Collections.Generic;

namespace CountSymbols
{
    public class ExecutePrgoram
    {
        static void Main()
        {
            string input = Console.ReadLine();
            
            var dictionary = new SortedDictionary<char, int>();

            foreach (var character in input)
            {
                if (dictionary.ContainsKey(character))
                {
                    dictionary[character]++;
                }
                else
                {
                    dictionary[character] = 1;
                }
            }

            foreach (var pair in dictionary)
            {
                Console.WriteLine(pair.Key + " " + pair.Value + " time/s");
            }
        }
    }
}
