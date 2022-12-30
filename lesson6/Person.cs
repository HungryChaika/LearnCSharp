using System;

namespace lesson6
{
    class Person
    {
        string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                if(value == "Tod")
                {
                    throw new MyException("Имя Tod не внушает доверие.", value);
                }
            }
        }
        int _Age;
        public int Age
        {
            get => _Age;
            set
            {
                if (value < 25)
                {
                    throw new MyException("Кондидат слишком молод.", value);
                }
                else if(value > 77)
                {
                    throw new MyException("Кондидат слишком стар.", value);
                }
            }
        }
        bool _Marriage;
        public bool Marriage
        {
            get => _Marriage;
            set
            {
                if(value)
                {
                    throw new MyException("Наличие брачных отношений противоречит нашим трдициям.", value);
                }
            }
        }
        public Person(string name, int age, bool marriage)
        {
            Name = name;
            Age = age;
            Marriage = marriage;
        }

    }
}
