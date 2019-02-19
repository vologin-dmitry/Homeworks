using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Invitation();
            int choose;
            choose = Convert.ToInt32(Console.ReadLine());
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
            int temp1 = 0;
            int temp2 = 0;
            int answer = 1;
            for (int i = 1; ; i++)
            {
                if (i == data)
                {
                    return answer;
                }
                temp1 = temp2;
                temp2 = answer;
                answer = temp1 + temp2;
            }
        }

        static void Fibonacci()
        {
            for (int i = 1; i < 47; i++)
            {
                Console.Write(Convert.ToString(IterativeFibonacci(i)) + " ");
            }
        }

        static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; ++i)
            {
                for (int j = i + 1; j < array.Length; ++j)
                {
                    if (Convert.ToInt32(array[j]) < Convert.ToInt32(array[i]))
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
            int[] array = new int[length];
            var rnd = new Random();
            for (int i = 0; i < length; ++i)
            {
                array[i] = rnd.Next(0, 20);
            }
            return array;
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i)
            {
                Console.Write(Convert.ToString(array[i]) + " ");
            }
        }
    }
}
