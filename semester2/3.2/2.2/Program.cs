using System;

 namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new HashTable();
            string choise = "-1";
            while (choise != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1, чтобы добавить значение в таблицу");
                Console.WriteLine("Введите 2, чтобы удалить значение из таблицы");
                Console.WriteLine("Введите 3, чтобы проверить принадлежность значения к таблице");
                Console.WriteLine("Введите 0, чтобы выйти");
                choise = Console.ReadLine();
                switch (choise)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите значение");
                            table.Add(Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите значение для удаления");
                            if (!table.Delete(Console.ReadLine()))
                            {
                                Console.WriteLine("Ошибка ! Проверьте правильность входных данных");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите значение для проверки");
                            if (table.Exists(Console.ReadLine()))
                            {
                                Console.WriteLine("Значение есть в таблице");
                            }
                            else
                            {
                                Console.WriteLine("Значения нет в таблице");
                            }
                            break;
                        }
                }
            }
            table.Clear();
        }
    }
} 