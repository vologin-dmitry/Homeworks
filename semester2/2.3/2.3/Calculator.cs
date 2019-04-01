using System;

namespace Calculator
{
    class Calculator
    {
        public int Count(string data, IStack myStack)
        {
            string[] dataArray = data.Split(' ');
            foreach (var value in dataArray)
            {
                if (IsOperator(value))
                {
                    if (myStack.GetSize() < 2)
                    {
                        Console.WriteLine("Произошла ошибка ! Проверьте правильность введённых данных");
                        return -1;
                    }
                    DoingThings(value, myStack);
                    continue;
                }
                if (IsDigit(value))
                {
                    myStack.Push(value);
                }
            }
            if (myStack.GetSize() == 0)
            {
                Console.WriteLine("Произошла ошибка ! Проверьте правильность введённых данных");
                return -1;
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
                if (letter - '0' > 9 || letter - '0' < 0)
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
                            Console.WriteLine("Ошибка ! На ноль делить нельзя");
                        }
                        myStack.Push(Convert.ToString(first / second));
                        break;
                    }
            }
        }
    }
}