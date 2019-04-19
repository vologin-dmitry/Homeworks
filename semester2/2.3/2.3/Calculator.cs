using System;

namespace Calculator
{
    /// <summary>
    /// Class which could calculate your expression with "Count" method. Can work with different stacks, stacks are provided in the constructor
    /// </summary>
    public class Calculator
    {

        private readonly IStack stack;
        /// <summary>
        /// Constructor, which requires stack, calculator will work on
        /// </summary>
        /// <param name="stack">Stack, calculator will work on</param>
        public Calculator(IStack stack)
        {
            this.stack = stack;
        }
        /// <summary>
        /// Default constructor, which creates calculator, that works on stack on list
        /// </summary>
        public Calculator()
        {
            this.stack = new StackOnList();
        }


        /// <summary>
        /// Counts the expression entered on some stack
        /// </summary>
        /// <param name="data">Expression to calculate</param>
        /// <returns>The answer to your expression</returns>
        public int Count(string data)
        {
            string[] dataArray = data.Split(' ');
            foreach (var value in dataArray)
            {
                int temp;
                if (!int.TryParse(value, out temp) && !IsOperator(value) || (IsOperator(value) && stack.Size < 2))
                {
                    throw new ArgumentException("Error ! Please check input data");
                }
                if (IsOperator(value))
                {
                    DoingThings(value, stack);
                    continue;
                }
                int number;
                if (int.TryParse(value, out number))
                {
                    stack.Push(number);
                }
            }
            if (stack.Size != 1)
            {
                throw new ArgumentException("Error ! Please check input data");
            }
            return stack.Pop();
        }

        private static bool IsOperator(string value)
            => (value == "+" || value == "-" || value == "*" || value == "/");


        private static void DoingThings(string value, IStack myStack)
        {
            int second = myStack.Pop();
            int first = myStack.Pop();
            switch (value)
            {
                case "+":
                    {
                        myStack.Push(first + second);
                        break;
                    }
                case "-":
                    {
                        myStack.Push(first - second);
                        break;
                    }
                case "*":
                    {
                        myStack.Push(first * second);
                        break;
                    }
                case "/":
                    {
                        if (second == 0)
                        {
                            throw new DivideByZeroException("Error ! Check your input data");
                        }
                        myStack.Push(first / second);
                        break;
                    }
            }
        }
    }
}