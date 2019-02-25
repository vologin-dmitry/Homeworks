using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Invitation();
            int choose = Convert.ToInt32(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        Console.WriteLine("Введите число");
                        int data = Convert.ToInt32(Console.ReadLine());
                        if (data < 0)
                        {
                            Console.WriteLine("Ошибка ! Введите корректные значение");
                            return;
                        }
                        Console.WriteLine(Factorial(data));
                        break;
                    }
                case 2:
                    {
                        Fibonacci();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите длину массива");
                        int size = Convert.ToInt32(Console.ReadLine());
                        if (size > 0)
                        {
                            int[] array = CreateAndFillArray(size);
                            PrintArray(array);
                            Sort(array);
                            Console.WriteLine();
                            PrintArray(array);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка ! Введите корректные значения");
                        }
                        break;
                    }
            }
        }

        static int Factorial(int data) => data <= 1 ? 1 : data * Factorial(data - 1);

        static int IterativeFibonacci(int data)
        {
            int tempPrevious = 0;
            int tempNext = 0;
            int answer = 1;
            var i = 1;
            while ( i < data)
            {
                tempPrevious = tempNext;
                tempNext = answer;
                answer = tempNext + tempPrevious;
                ++i;
            }
            return answer;
        }

        static void Fibonacci()
        {
            for (int i = 1; i < 47; i++)
            {
                Console.Write($"{IterativeFibonacci(i)} ");
            }
        }

        static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if ((array[j]) < (array[i]))
                    {
                        int temp = array[j];
                        array[j] = array[i];
                        array[i] = temp;
                    }
                }
            }
        }

        static void Invitation()
        {
            Console.WriteLine("Введите 1, чтобы посчитать факториал");
            Console.WriteLine("Введите 2, чтобы вывести числа фибоначчи");
            Console.WriteLine("Введите 3, чтобы отсортировать массив");
        }

        static int[] CreateAndFillArray(int length)
        {
            var array = new int[length];
            var rnd = new Random();
            for (int i = 0; i < length; ++i)
            {
                array[i] = rnd.Next(0, 20);
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            foreach (int element in array)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
