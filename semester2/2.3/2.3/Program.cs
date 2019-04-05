using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, чтобы использовать стэк на массиве");
            Console.WriteLine("Введите 2, чтобы использовать стэк на списке");
            int choose = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите выражение");
            string toCount = Console.ReadLine();
            var calculator = new Calculator();
            if (choose == 1)
            {
                var stack = new StackOnArray();
                Console.WriteLine(calculator.Count(toCount, stack));
                stack.Clear();
            }
            if (choose == 2)
            {
                var stack = new StackOnList();
                Console.WriteLine(calculator.Count(toCount, stack));
                stack.Clear();
            }
        }
    }
}
