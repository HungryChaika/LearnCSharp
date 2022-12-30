using System;

namespace lesson5
{
    public abstract class Animal
    {
        public string Name;
        double _FullnessOfStomach = 10.0;
        public double FullnessOfStomach
        {
            get => _FullnessOfStomach;
        }
        public Animal(string Name)
        {
            this.Name = Name;
        }
        public abstract void Move();
        public void FoodSearch()
        {
            Console.WriteLine($"{Name} ищет пропитание");
        }
        public void Eat(double Meal)
        {
            Console.WriteLine($"{Name} ест на {Meal} единиц");
            _FullnessOfStomach += Meal;
            if (_FullnessOfStomach > 100)
            {
                Console.WriteLine("Рвота");
                _FullnessOfStomach = 100.0;
            }
        }
        public void Sleep()
        {
            Console.WriteLine($"{Name} Спит");
        }
        public abstract void Reproduction();
        public void Death()
        {
            Console.WriteLine($"{Name} умирает");
        }
    }
}
