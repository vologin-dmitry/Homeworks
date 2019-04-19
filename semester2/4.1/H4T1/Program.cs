using System;

namespace H4T1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.BuildFromfile("test.txt");
            Console.WriteLine(tree.GetLine());
            Console.WriteLine(tree.Count());
            tree.Clear();
        }
    }
}
