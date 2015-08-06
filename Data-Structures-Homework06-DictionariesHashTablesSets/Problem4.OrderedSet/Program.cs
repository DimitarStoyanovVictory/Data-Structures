namespace OrderedSet
{
    public class ExecuteProgram
    {
        static void Main()
        {
            var example1 = new OrderedSet<int>();
            example1.Add(17);
            example1.Add(9);
            example1.Add(12);
            example1.Add(19);
            example1.Add(6);
            example1.Add(25);
            example1.Add(8);

            example1.Remove(9);

            var example2 = new OrderedSet<int>();

            example2.Add(17);
            example2.Add(9);
            example2.Add(19);
            example2.Add(6);
            example2.Add(12);
            example2.Add(25);
            example2.Add(22);
            example2.Add(33);
            example2.Add(28);
            example2.Add(35);
            example2.Add(3);
            example2.Add(2);
            example2.Add(1);
            example2.Add(5);
            example2.Add(4);
            example2.Add(11);
            example2.Add(13);
            example2.Add(26);

            example2.Remove(9);
        }
    }
}
