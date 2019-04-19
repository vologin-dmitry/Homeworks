using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, чтобы использовать стек на массиве");
            Console.WriteLine("Введите любое другое число, чтобы использовать стек на списке");
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите выражение");
            string toCount = Console.ReadLine();
            var stack = choise == 1 ? (IStack) new StackOnArray() : (IStack) new StackOnList();
            var calculator = new Calculator(stack);
            try
            {
                Console.WriteLine(calculator.Count(toCount));
            }
            catch (Exception ex) when (ex is DivideByZeroException || ex is ArgumentException)
            {
                Console.WriteLine("Ошибка ! Проверьте введенную строку");
            }
            stack.Clear();
        }
    }
}
