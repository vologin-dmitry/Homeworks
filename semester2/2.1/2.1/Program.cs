using System;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List();
            string choose = "-1";
            while (choose != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1, чтобы добавить значение в список");
                Console.WriteLine("Введите 2, чтобы удалить значение из списка");
                Console.WriteLine("Введите 3, чтобы узнать количество элементов в списке");
                Console.WriteLine("Введите 4, чтобы получить значение элемента по позиции");
                Console.WriteLine("Введите 5, чтобы установить значение элемента по позиции");
                Console.WriteLine("Введите 0, чтобы выйти");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите значение");
                            string input = Console.ReadLine();
                            Console.WriteLine("Введите номер элемента");
                            string position = Console.ReadLine();
                            if (!list.Add(input, Convert.ToInt32(position)))
                            {
                                Console.WriteLine("Ошибка! проверьте правильность введенных данных");
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите номер элемента");
                            if (!list.Delete(Convert.ToInt32(Console.ReadLine())))
                            {
                                Console.WriteLine("Ошибка! проверьте правильность введенных данных");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine(list.GetSize());
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("Введите номер элемента");
                            Console.WriteLine(list.GetDataOn(Convert.ToInt32(Console.ReadLine())));
                            break;
                        }
                    case "5":
                        {
                            Console.WriteLine("Введите значение");
                            string input = Console.ReadLine();
                            Console.WriteLine("Введите номер элемента");
                            string position = Console.ReadLine();
                            if (!list.SetDataOn(input, Convert.ToInt32(position)))
                            {
                                Console.WriteLine("Ошибка! проверьте правильность введенных данных");
                            }
                            break;
                        }
                }
            }
            list.Clear();
        }
    }
}