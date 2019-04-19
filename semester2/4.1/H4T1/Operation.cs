using System;

namespace H4T1
{
    /// <summary>
    /// Node, representing an operation
    /// </summary>
    public class Operation : INode
    {
        public INode LeftChild { get; set; }
        public INode RightChild { get; set; }
        private readonly char data;

        /// <summary>
        /// Creates a node, representing operation of some type
        /// </summary>
        /// <param name="data">Type of operation</param>
        public Operation(char data)
        {
            if (!IsOperation(data))
            {
                throw new FormatException();
            }
            this.data = data;
        }

        /// <summary>
        /// Returns string, representing the expression of the tree, which head is this node
        /// </summary>
        /// <returns>String, representing the expression of the tree, which head is this node</returns>
        public string GetLine()
        {
            return "( " + data + " " + LeftChild.GetLine() + " " + RightChild.GetLine() + " )";
        }

        /// <summary>
        /// Prints a string, representing the expression of the tree, which head is this node
        /// </summary>
        public void Print()
        {
            Console.WriteLine(GetLine());
        }

        /// <summary>
        /// Performs the entered operation with the right and left child
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            switch (data)
            {
                case '+':
                    {
                        return LeftChild.Count() + RightChild.Count();
                    }
                case '-':
                    {
                        return LeftChild.Count() - RightChild.Count();
                    }
                case '*':
                    {
                        return LeftChild.Count() * RightChild.Count();
                    }
                case '/':
                    {
                        if (RightChild.Count() == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        return LeftChild.Count() / RightChild.Count();
                    }
            }
            return -1;
        }

        /// <summary>
        /// Creates node in given triplet
        /// </summary>
        /// <param name="tripletHead">Head of the triplet, where you want to create node</param>
        /// <param name="data">Value of the node, you want to create</param>
        /// <returns>Triplet, with created node</returns>
        public static INode AddNode(Operation tripletHead, string data)
        {
            if (tripletHead == null)
            {
                tripletHead = new Operation(data[0]);
                return tripletHead;
            }
            if (tripletHead.LeftChild == null)
            {
               tripletHead.LeftChild = new Operation(data[0]);
               return tripletHead;
            }
            if (tripletHead.RightChild == null)
            {
               tripletHead.RightChild = new Operation(data[0]);
               return tripletHead;
            }
            throw new FormatException();
        }

        public static bool IsOperation(char data)
            => data == '+' || data == '-' || data == '*' || data == '/';
    }
}