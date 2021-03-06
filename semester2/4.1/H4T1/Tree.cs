﻿using System;
using System.IO;

namespace H4T1
{
    public class Tree
    {
        private INode head;

        /// <summary>
        /// Constructor, which builds tree
        /// </summary>
        /// <param name="input">The expression to convert to a tree</param>
        public Tree(string input)
        {
            Build(input);
        }

        /// <summary>
        /// Deafult constructor
        /// </summary>
        public Tree() { }

        /// <summary>
        /// Counts an expression parsed by a tree
        /// </summary>
        /// <returns>The answer to the expression</returns>
        public int Count()
            => head?.Count() ?? throw new InvalidOperationException();

        /// <summary>
        /// Converts tree to expression in string format
        /// </summary>
        /// <returns>A string representing a tree expression</returns>
        public string GetLine()
            => head?.GetLine() ?? throw new InvalidOperationException();

        /// <summary>
        /// Deletes tree
        /// </summary>
        public void Clear()
        {
            head = null;
        }

        /// <summary>
        /// Creates a parse tree for the entered expression from file
        /// </summary>
        /// <param name="filePath">Path of the file with string</param>
        public void BuildFromfile(string filePath)
        {
            StreamReader fileReader = new StreamReader(filePath);
            if (fileReader == null)
            {
                throw new FileNotFoundException();
            }
            string line = fileReader.ReadLine();
            fileReader.Close();
            Build(line);

        }

        /// <summary>
        /// Creates a parse tree for the entered expression
        /// </summary>
        /// <param name="input">The expression to convert to a tree</param>
        public void Build(string input)
        {
            Clear();
            int temp = 0;
            head = BuildHelperRecursive(input, ref temp, head);
        }

        private INode BuildHelperRecursive(string input,ref int i, INode current)
        {
            for (; i < input.Length; ++i)
            {
                switch (input[i])
                {
                    case ' ':
                        {
                            continue;
                        }
                    case '(':
                        {
                            i++;
                            if (current == null)
                            {
                                current = BuildHelperRecursive(input, ref i, current);
                                continue;
                            }
                            if (((Operation)current).LeftChild == null)
                            {
                                ((Operation)current).LeftChild = BuildHelperRecursive(input, ref i, ((Operation)current).LeftChild);
                                continue;
                            }
                            ((Operation)current).RightChild = BuildHelperRecursive(input, ref i, ((Operation)current).RightChild);
                            break;
                        }
                    case ')':
                        {
                            return current;
                        }
                    default:
                        {
                            if (Operation.IsOperation(input[i]))
                            {
                                current = Operation.AddNode((Operation)current, Convert.ToString(input[i]));
                            }
                            else
                            {
                                string maybeInteger = "";
                                do
                                {
                                    maybeInteger += input[i];
                                    i++;
                                }
                                while (char.IsDigit(input[i]));
                                current = Operand.AddNode((Operation)current, maybeInteger);
                            }
                            break;
                        }
                }
            }
            return current;
        }
    }
}