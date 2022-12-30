using System;

namespace lesson5
{
    public class Wyvern : Animal
    {
        public Wyvern(string Name) : base(Name) { }
        public override void Move()
        {
            Console.WriteLine($"Виверна летит");
        }
        public override void Reproduction()
        {
            Console.WriteLine($"На свет появляется новая виверна");
        }
    }
}
