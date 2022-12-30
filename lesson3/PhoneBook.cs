using System;

namespace lesson3
{   
    public static class PhoneBook
    {
        public delegate void OutputToConsole(string Message);
        public static event OutputToConsole? AddUserConsoleInfo;
        public static event OutputToConsole? DeleteUserConsoleInfo;
        public static event OutputToConsole? GetUsersFromFileConsoleInfo;
        public static event OutputToConsole? SaveUsersToFileConsoleInfo;
        static string Path = "../../../phonebook.txt";
        public static List<Abonent> PhoneList = new();
        public static void Init()
        {
            string[] Text = File.ReadAllText(Path).Split("\n");
            foreach (string Str in Text)
            {
                if (Str.Length > 0)
                {
                    string[] Elems = Str.Replace("\r", "").Split(" - ");
                    PhoneList.Add(new Abonent(Elems[0], Elems[1]));
                }
                else
                {
                    GetUsersFromFileConsoleInfo?.Invoke("Пользователи взяты из файла.");
                    break;
                }
            }
        }
        public static void PrintPhoneList()
        {
            if (PhoneList.Count > 0)
            {
                foreach (Abonent Elem in PhoneList)
                {
                    Console.WriteLine($"{Elem.Name} - {Elem.PhoneNumber};");
                }
            }
            else
            {
                Console.WriteLine("Номера отсутствуют;");
            }
        }
        public static void AddAbonent(string Name, string PhoneNumber)
        {
            if (PhoneList.Find(Elem => Elem.Name == Name) is null &&
                PhoneList.Find(Elem => Elem.PhoneNumber == PhoneNumber) is null)
            {
                PhoneList.Add(new Abonent(Name.ToLower(), PhoneNumber));
                AddUserConsoleInfo?.Invoke("Пользователь добавлен.");
            }
        }
        public static void DeleteAbonentUsingName(string Name)
        {
            int IndexAbonet = 0;
            while (IndexAbonet < PhoneList.Count)
            {
                if (PhoneList[IndexAbonet].Name == Name)
                {
                    PhoneList.RemoveAt(IndexAbonet);
                    DeleteUserConsoleInfo?.Invoke("Пользователь удалён.");
                    break;
                }
                IndexAbonet++;
            }
        }
        public static void DeleteAbonentUsingPhoneNumber(string PhoneNumber)
        {
            int IndexAbonet = 0;
            while(IndexAbonet < PhoneList.Count)
            {
                if (PhoneList[IndexAbonet].PhoneNumber == PhoneNumber)
                {
                    PhoneList.RemoveAt(IndexAbonet);
                    DeleteUserConsoleInfo?.Invoke("Пользователь удалён.");
                    break;
                }
                IndexAbonet++;
            }
        }
        public static Abonent? GetAbonentUsingName(string? Name)
        {
            return PhoneList.Find(Elem => Elem.Name.Contains(Name));
        }
        public static Abonent? GetAbonentUsingPhoneNumber(string? PhoneNumber)
        {
            return PhoneList.Find(Elem => Elem.PhoneNumber.Contains(PhoneNumber));
        }
        public static void SaveAndExit()
        {
            string[] Text = new string[PhoneList.Count];
            int Index = 0;
            foreach(Abonent User in PhoneList)
            {
                Text[Index] = $"{User.Name} - {User.PhoneNumber}";
                Index++;
            }
            File.WriteAllLines(Path, Text);
            SaveUsersToFileConsoleInfo?.Invoke("Пользователи сохранены.");
        }
    }
}
