using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H4T1
{
    /// <summary>
    /// Node, representing an integer number
    /// </summary>
    public class Operand : INode
    {
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }
        private int value;

        /// <summary>
        /// Creates an operand with a given value
        /// </summary>
        /// <param name="value">Value of an operand</param>
        public Operand(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Returns value of this node in string format
        /// </summary>
        /// <returns>Value of this node in string format</returns>
        public string GetLine()
        {
            return value.ToString();
        }

        /// <summary>
        /// Prints value of this node in string format
        /// </summary>
        public void Print()
        {
            Console.WriteLine(GetLine());
        }

        /// <summary>
        /// Returns the value of the operand
        /// </summary>
        /// <returns>Value of the operand</returns>
        public int Count()
            => value;

        /// <summary>
        /// Creates node in given triplet
        /// </summary>
        /// <param name="tripletHead">Head of the triplet, where you want to create node</param>
        /// <param name="value">Value of the node, you want to create</param>
        /// <returns>Triplet, with created node</returns>
        public static INode AddNode(Operation tripletHead, string value)
        {
            int temp;
            if (int.TryParse(value, out temp))
            {
                if (tripletHead.LeftChild == null)
                {
                    tripletHead.LeftChild = new Operand(temp);
                    return tripletHead;
                }
                if (tripletHead.RightChild == null)
                {
                    tripletHead.RightChild = new Operand(temp);
                    return tripletHead;
                }
            }
            throw new FormatException();
        }

    }
}
