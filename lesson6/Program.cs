namespace lesson6
{
    class programm
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Набор персонала в компанию:\n");
            try
            {
                Console.WriteLine("Первый претендент:\nАлександр 20-ти летнего возраста, женат;");
                Person Person1 = new("Александр", 20, true);
            }
            catch(MyException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine("Второй претендент:\nИрина 80-ти летнего возраста, замужем;");
                Person Person2 = new("Ирина", 80, true);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Console.WriteLine("Первый претендент:\nTod 30-ти летнего возраста, не женат;");
                Person Person3 = new("Tod", 30, false);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}