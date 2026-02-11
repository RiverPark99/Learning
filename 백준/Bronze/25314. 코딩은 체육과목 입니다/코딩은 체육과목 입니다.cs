class Program
    {
        static void Main(string[] args)
        {

            string LONG = "long ";
            string INT = "int";
            string result = "";

            int N = Convert.ToInt32(Console.ReadLine());

            int divideN = N / 4;

            for (int i = 0; i < divideN; i++)
            {
                result = result + LONG;
            }

            result = result + INT;

            Console.WriteLine(result);
        }
    }