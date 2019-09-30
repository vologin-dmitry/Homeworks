using System;

namespace H7T1
{
    /// <summary>
    /// A thing that can count simple expressions.
    /// </summary>
    public static class Counter
    {
        /// <summary>
        /// Counts a simple binary expression
        /// </summary>
        /// <param name="first">First element of your expression</param>
        /// <param name="second">Second element of your expression</param>
        /// <param name="operation">Plus, minux, multiplicate or divide sign</param>
        /// <returns>Result of the expression or second element if operation is not supported</returns>
        public static float Count(float first, float second, string operation)
        {
            switch (operation)
            {
                case "+":
                    {
                        return first + second;
                    }
                case "-":
                    {
                        return first - second;
                    }
                case "*":
                    {
                        return first * second;
                    }
                case "/":
                    {
                        if (second == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        return first / second;
                    }
            }
            return second;
        }
    }
}
