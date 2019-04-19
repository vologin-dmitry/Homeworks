namespace H4T1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.BuildFromfile("test.txt");
            string line = tree.GetLine();
            int answer = tree.Count();
            tree.Clear();
        }
    }
}
