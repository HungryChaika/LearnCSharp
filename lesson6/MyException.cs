
namespace lesson6
{
    class MyException : Exception
    {
        public string Name { get; }
        public int Age { get; }
        public bool Marriage { get; }
        public MyException(string Message, string name) : base(Message)
        {
            Name = name;
        }
        public MyException(string Message, int age) : base(Message)
        {
            Age = age;
        }
        public MyException(string Message, bool marriage) : base(Message)
        {
            Marriage = marriage;
        }
    }
}
