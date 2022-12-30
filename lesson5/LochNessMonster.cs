using System;

namespace lesson5
{
    internal class LochNessMonster : Animal
    {
        public LochNessMonster(string Name) : base(Name) { }
        public override void Move()
        {
            Console.WriteLine($"Лохнесское чудовище плывёт");
        }
        public override void Reproduction()
        {
            Console.WriteLine($"На свет появляется новый Несси");
        }
    }
}
