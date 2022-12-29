using System;

namespace lesson3
{
    class Programm
    {
        public static void Main(string[] args)
        {
            PhoneBook.Init();
            Console.WriteLine("Телефонная книга.");
            Console.WriteLine("\nОпции:\n");
            Console.Write(
                "0) Сохранить и выйти;\n" +
                "1) Получить пользователя по номеру телефона;\n" +
                "2) Получить пользователя по имени;\n" +
                "3) Показать список пользователей;\n" +
                "4) Добавить пользователя;\n" +
                "5) Удалять пользователя по номеру телефона;\n" +
                "6) Удалять пользователя по имени;\n"
                );
            ConsoleKeyInfo Mode;
            do
            {
                Console.Write("\nНажмите на цифру, обозначающую опцию.\n\n");
                Mode = Console.ReadKey(true);
                switch (Mode.Key) {
                    case ConsoleKey.D0:
                        {
                            PhoneBook.SaveAndExit();
                            break;
                        }
                    case ConsoleKey.D1:
                        {
                            Console.Write("\nВведите номер телефона:");
                            string PhoneNumber = Console.ReadLine();
                            Abonent? User = PhoneBook.GetAbonentUsingPhoneNumber(PhoneNumber);
                            if(User is not null && User.Name is not null && User.PhoneNumber is not null)
                            {
                                Console.WriteLine($"Пользователь {User.Name} с номером: {User.PhoneNumber};\n");
                            }
                            else
                            {
                                Console.WriteLine($"Пользователя с номером {PhoneNumber} не существует;\n");
                            }
                            break;
                        }
                    case ConsoleKey.D2:
                        {
                            Console.Write("\nВведите имя пользователя:");
                            string Name = Console.ReadLine();
                            Abonent? User = PhoneBook.GetAbonentUsingName(Name);
                            if (User is not null && User.Name is not null && User.PhoneNumber is not null)
                            {
                                Console.WriteLine($"Пользователь {User.Name} с номером: {User.PhoneNumber};\n");
                            }
                            else
                            {
                                Console.WriteLine($"Пользователя с именем {Name} не существует;\n");
                            }
                            break;
                        }
                    case ConsoleKey.D3:
                        {
                            Console.WriteLine("Список пользователей:");
                            PhoneBook.PrintPhoneList();
                            break;
                        }
                    case ConsoleKey.D4:
                        {
                            Console.Write("\nВведите имя пользователя:");
                            string Name = Console.ReadLine();
                            Console.Write("\nВведите номер телефона:");
                            string PhoneNumber = Console.ReadLine();
                            PhoneBook.AddAbonent(Name, PhoneNumber);
                            break;
                        }
                    case ConsoleKey.D5:
                        {
                            Console.Write("\nВведите номер телефона:");
                            string PhoneNumber = Console.ReadLine();
                            PhoneBook.DeleteAbonentUsingPhoneNumber(PhoneNumber);
                            break;
                        }
                    case ConsoleKey.D6:
                        {
                            Console.Write("\nВведите имя пользователя:");
                            string Name = Console.ReadLine();
                            PhoneBook.DeleteAbonentUsingName(Name);
                            break;
                        }
                }
            }
            while (Mode.Key != ConsoleKey.D0);



        }
    }
}