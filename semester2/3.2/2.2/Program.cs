using System;

 namespace Table
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите 1, чтобы использовать стандартную хэш функцию");
            Console.WriteLine("Введите любое другое число, чтобы использовать хэш-фукцию на умножении");
            string hashChoice = Console.ReadLine();
            IHash hashFunc = hashChoice == "1" ? (IHash) new DefaultHashFunction() : (IHash) new MultiplicationHashFunction();
            var table = new HashTable(hashFunc);
            string choice = "-1";
            while (choice != "0")
            {
                Console.WriteLine();
                Console.WriteLine("Введите 1, чтобы добавить значение в таблицу");
                Console.WriteLine("Введите 2, чтобы удалить значение из таблицы");
                Console.WriteLine("Введите 3, чтобы проверить принадлежность значения к таблице");
                Console.WriteLine("Введите 0, чтобы выйти");
                choice = Console.ReadLine();
                switch (choice)
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