namespace lesson5
{
    class Programm
    {
        public static void Main(string[] args)
        {
            MyWyvern();
            MylochNessMonster();
        }
        static void MyWyvern()
        {
            Animal wyvern = new Wyvern("Виверна");
            //Animal lochNessMonster = new LochNessMonster("Лохнесское чудовище");
            Console.WriteLine("==============================");
            Console.WriteLine($"Это {wyvern.Name}");
            wyvern.Move();
            Console.WriteLine($"Заполненность желудка {wyvern.FullnessOfStomach} единиц");
            wyvern.FoodSearch();
            wyvern.Eat(20.0);
            Console.WriteLine($"Заполненность желудка {wyvern.FullnessOfStomach} единиц");
            wyvern.Sleep();
            wyvern.Reproduction();
            wyvern.Death();
            Console.WriteLine("==============================");
        }
        static void MylochNessMonster()
        {
            Animal lochNessMonster = new LochNessMonster("Лохнесское чудовище");
            Console.WriteLine("==============================");
            Console.WriteLine($"Это {lochNessMonster.Name}");
            lochNessMonster.Move();
            Console.WriteLine($"Заполненность желудка {lochNessMonster.FullnessOfStomach} единиц");
            lochNessMonster.FoodSearch();
            lochNessMonster.Eat(95.0);
            Console.WriteLine($"Заполненность желудка {lochNessMonster.FullnessOfStomach} единиц");
            lochNessMonster.Sleep();
            lochNessMonster.Reproduction();
            lochNessMonster.Death();
            Console.WriteLine("==============================");
        }
    }
}