using System;

namespace lesson4
{
    class Programm
    {
        public static void Main(string[] args)
        {
            MyList<int> Result = new MyList<int>();
            Console.WriteLine($"Проверка.\n\nРазмер: {Result.Count}\nДобавление 3-х элементов.");
            Result.Add(1);
            Result.Add(5);
            Result.Add(90);
            WriteResult(Result);
            Console.WriteLine($"Размер: {Result.Count}\nУдаление по индесу (1).");
            Result.DeleteByIndex(1);
            Console.WriteLine($"Размер: {Result.Count}");
            WriteResult(Result);
            Console.WriteLine("Удаление по значению (90).");
            Result.DeleteByElement(90);
            Console.WriteLine($"Размер: {Result.Count}");
            WriteResult(Result);
        }
        static void WriteResult<T>(MyList<T> Result)
        {
            for (int i = 0; i < Result.Count; i++)
            {
                Console.WriteLine($"{i}: {Result[i]}");
            }
        }
    }
}