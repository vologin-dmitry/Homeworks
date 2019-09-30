using System;

namespace UniqueList
{
    class Program
    {
        static void Main(string[] args)
        {
            UniqueList list = new UniqueList();
            list.Add("first", 1);
            list.Add("second", 2);
            ///Assert.AreEqual(list.GetDataOn(1), "first");
            Console.WriteLine(list.GetDataOn(2));
        }
    }
}
