using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4T1
{
    public interface INode
    {
        /// <summary>
        /// Counts a tree, which head is this node
        /// </summary>
        /// <returns>The answer to the expression</returns>
        int Count();

        /// <summary>
        /// Returns string, representing the expression of the tree, which head is this node
        /// </summary>
        /// <returns>String, representing the expression of the tree, which head is this node</returns>
        string GetLine();


        /// <summary>
        /// Printing string, representing the expression of the tree, which head is this node
        /// </summary>
        void Print();
    }
}