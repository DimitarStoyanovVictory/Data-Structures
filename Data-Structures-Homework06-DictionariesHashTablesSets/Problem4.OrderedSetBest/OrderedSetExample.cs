namespace OrderedSet
{
    using System;

    public class OrderedSetExample
    {
        public static void Main()
        {
            var set = new OrderedSet<int>();
            set.Add(17);
            set.Add(9);
            set.Add(12);
            set.Add(6);
            set.Add(25);
            set.Add(4);
            set.Add(8);
            set.Add(10);
            set.Add(14);
            set.Add(18);
            set.Add(22);
            set.Add(20);
            set.Add(24);
            set.Add(28);
            set.Add(26);
            set.Add(30);
            set.Add(2);
            set.Add(1);

            Console.WriteLine(set.Contains(12));
            Console.WriteLine(set.Contains(60));

            foreach (var child in set)
            {
                Console.WriteLine(child);
            }

            // set.Remove(12);
            set.Remove(9);
        }
    }
}
