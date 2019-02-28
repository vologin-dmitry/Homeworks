using System;

 namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            var Table = new HashTable();
            string choose = "-1";
            while (choose != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1, чтобы добавить значение в таблицу");
                Console.WriteLine("Введите 2, чтобы удалить значение из таблицы");
                Console.WriteLine("Введите 3, чтобы проверить принадлежность значения к таблице");
                Console.WriteLine("Введите 0, чтобы выйти");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        {
                            Console.WriteLine("Введите значение");
                            Table.Add(Console.ReadLine());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Введите значение для удаления");
                            if (!Table.Delete(Console.ReadLine()))
                            {
                                Console.WriteLine("Ошибка ! Проверьте правильность входных данных");
                            }
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("Введите значение для проверки");
                            if (Table.Exists(Console.ReadLine()))
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
            Table.Clear();
        }
    }
} 