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
            IStack stack;
            if (choose == 1)
            {
                stack = new StackOnArray();
            }
            else
            {
                stack = new StackOnList();
            }
            try
            {
                Console.WriteLine(calculator.Count(toCount, stack));
            }
            catch (Exception ex)
            {
                if(ex is DivideByZeroException || ex is ArgumentException)
                {
                    Console.WriteLine("Ошибка ! Проверьте введенную строку");
                }
            }
            stack.Clear();
        }
    }
}
