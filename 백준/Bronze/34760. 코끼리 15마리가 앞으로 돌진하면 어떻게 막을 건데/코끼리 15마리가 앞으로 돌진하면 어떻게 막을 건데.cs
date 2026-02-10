class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            int[] numAr = { 
                    int.Parse(input[0]),
                    int.Parse(input[1]),
                    int.Parse(input[2]),
                    int.Parse(input[3]),
                    int.Parse(input[4]),
                    int.Parse(input[5]),
                    int.Parse(input[6]),
                    int.Parse(input[7]),
                    int.Parse(input[8]),
                    int.Parse(input[9]),
                    int.Parse(input[10]),
                    int.Parse(input[11]),
                    int.Parse(input[12]),
                    int.Parse(input[13]),
                    int.Parse(input[14])
            };

            int result = 0;
            int highnum = 0;
            bool samehighnum = false;

            for (int i = 0; i < numAr.Length; i++)
            {
                if (highnum < numAr[i])
                {
                    highnum = numAr[i];
                    samehighnum = false;
                }
                else if(highnum == numAr[i])
                {
                    samehighnum = true;
                }
            }

            if (!samehighnum && highnum.Equals(numAr[14]))
            {
                result = numAr[14];
            }
            else
            {
                result = highnum + 1;
            }
            
            Console.WriteLine(result);
        }
    }