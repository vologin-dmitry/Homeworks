using System;

namespace FourthAndFifth
{
    class Program
    {
        static void Main(string[] args)
        {
            Invitation();
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1)
            {
                Console.WriteLine("Введите размер массива");
                int size = Convert.ToInt32(Console.ReadLine());
                if (size > 0 && size % 2 != 0)
                {
                    int[,] array = CreateAndFillArray(size, size);
                    PrintArray(array);
                    SpiralPrint(array);
                }
                else
                {
                    Console.WriteLine("Некорректные данные");
                }
            }
            else
            {
                Console.WriteLine("Введите высоту и длину массива");
                string dimensions = Console.ReadLine();
                string[] size = dimensions.Split(' ');
                int[,] data = CreateAndFillArray(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
                PrintArray(data);
                ArraySort(data);
                PrintArray(data);
            }
        }

        static void SpiralPrint(int[,] array)
        {
            SpiralRecursive(array, 0, array.GetLength(1));
        }

        static void SpiralRecursive(int[,] array, int jump, int length)
        {
            if (jump < length / 2)
            {
                SpiralRecursive(array, jump + 1, length);
            }
            if (jump == length / 2)
            {
                Console.Write($"{array[jump, jump]} ");
                return;
            }
            for (int i = length - jump - 2; i > jump; --i)
            {
                Console.Write($"{Convert.ToString(array[i, jump])} ");
            }
            for (int i = jump; i < length - 1 - jump; ++i)
            {
                Console.Write($"{Convert.ToString(array[jump, i])} ");
            }
            for (int i = jump; i < length - 1 - jump; ++i)
            {
                Console.Write($"{Convert.ToString(array[i, length - jump - 1])} ");
            }
            for (int i = length - 1 - jump; i >= jump; --i)
            {
                Console.Write($"{Convert.ToString(array[length - jump - 1, i])} ");
            }
        }

        static void ArraySort(int[,] array)
        {
            for (int i = 0; i < array.GetLength(1) - 1; ++i)
            {
                for (int j = i + 1; j < array.GetLength(1); ++j)
                {
                    if (array[0, i] > array[0, j])
                    {
                        ColumnSwap(array, i, j);
                    }
                }
            }
        }

        static void ColumnSwap(int[,] array, int first, int second)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                int temp = array[i, first];
                array[i, first] = array[i, second];
                array[i, second] = temp;
            }
        }

        static void Invitation()
        {
            Console.WriteLine("Введите 1, чтобы вывести массив по спирали");
            Console.WriteLine("Введите 2, чтобы отсортировать массив по столбцам");
        }

        static int[,] CreateAndFillArray(int height, int length)
        {
            int[,] array = new int[height, length];
            var rnd = new Random();
            for (int i = 0; i < height; ++i)
            {
                for (int j = 0; j < length; ++j)
                {
                    array[i, j] = rnd.Next(0, 50);
                }
            }
            return array;
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); ++i)
            {
                for (int j = 0; j < array.GetLength(1); ++j)
                {
                    Console.Write($"{(array[i, j])} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}