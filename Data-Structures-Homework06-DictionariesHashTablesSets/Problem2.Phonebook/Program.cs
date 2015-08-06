using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    public class ExecuteProgram
    {
        static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            string input = "";
            string[] inputArrays;
            while (true)
            {
                input = Console.ReadLine();
                if (input == "search")
                {
                    break;
                }

                inputArrays = input.Split('-');
                phonebook.Add(inputArrays[0], inputArrays[1]);
            }

            while (true)
            {
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }

                if (phonebook.Keys.Contains(input))
                {
                    Console.WriteLine("{0} -> {1}", phonebook.Keys.FirstOrDefault(key => key == input), phonebook[input]);
                }
                else
                {
                    Console.WriteLine("Contact {0} does not exist.", input);
                }
            }
        }
    }
}
