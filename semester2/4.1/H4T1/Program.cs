using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4T1
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tree = new Tree();
            tree.Build("( *( + 1 1 ) ( / ( + 3 2 ) 4 )");
            string line = tree.GetLine();
            int answer = tree.Count();
            tree.Clear();
            tree.GetLine();
        }
    }
}
