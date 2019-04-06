using System;

namespace Calculator
{
    public class Calculator
    {
        /// <summary>
        /// Counts the expression entered on some stack
        /// </summary>
        /// <param name="data">Expression to calculate</param>
        /// <param name="myStack">Stack, you want to use</param>
        /// <returns>The answer to your expression</returns>
        public int Count(string data, IStack myStack)
        {
            string[] dataArray = data.Split(' ');
            foreach (var value in dataArray)
            {
                if ((!IsDigit(value) && !IsOperator(value)) || ((IsOperator(value) && myStack.GetSize() < 2)))
                {
                    throw new ArgumentException("Error ! Please check input data");
                }
                if (IsOperator(value))
                {
                    DoingThings(value, myStack);
                    continue;
                }
                if (IsDigit(value))
                {
                    myStack.Push(value);
                }
            }
            if (myStack.GetSize() != 1)
            {
                throw new ArgumentException("Error ! Please check input data");
            }
            return Convert.ToInt32(myStack.Pop());
        }

        private static bool IsOperator(string value)
        {
            return (value == "+" || value == "-" || value == "*" || value == "/");
        }

        private static bool IsDigit(string value)
        {

            foreach (char letter in value)
            {
                if ((letter - '0' > 9 || letter - '0' < 0) && value[0] != '-')
                {
                    return false;
                }
            }
            return true;
        }

        private static void DoingThings(string value, IStack myStack)
        {
            int second = Convert.ToInt32(myStack.Pop());
            int first = Convert.ToInt32(myStack.Pop());
            switch (value)
            {
                case "+":
                    {
                        myStack.Push(Convert.ToString(first + second));
                        break;
                    }
                case "-":
                    {
                        myStack.Push(Convert.ToString(first - second));
                        break;
                    }
                case "*":
                    {
                        myStack.Push(Convert.ToString(first * second));
                        break;
                    }
                case "/":
                    {
                        if (second == 0)
                        {
                            throw new DivideByZeroException("Error ! Check your input data");
                        }
                        myStack.Push(Convert.ToString(first / second));
                        break;
                    }
            }
        }
    }
}