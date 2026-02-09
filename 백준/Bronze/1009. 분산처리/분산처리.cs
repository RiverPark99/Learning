class Program
    {
        static void Main(string[] args)
        {
            int T = int.Parse(Console.ReadLine());

            for (int i = 0; i < T; i++)
            {
                string[] input = Console.ReadLine().Split();
                int num_a = int.Parse(input[0]);
                int num_b = int.Parse(input[1]);

                int num_A = num_a % 10;
                int num_B = 0;
                int result = 0;

                switch (num_A)
                {
                    case 0:
                        {
                            result = 10;
                            break;
                        }

                    case 1:
                        {
                            result = 1;
                            break;
                        }

                    case 2://num_b - 1
                        {
                            num_B = (num_b - 1) % 4;
                            if (num_B == 0) result = 2;
                            else if (num_B == 1) result = 4;
                            else if (num_B == 2) result = 8;
                            else result = 6;
                            break;
                        }

                    case 3:
                        {
                            num_B = (num_b - 1) % 4;
                            if (num_B == 0) result = 3;
                            else if (num_B == 1) result = 9;
                            else if (num_B == 2) result = 7;
                            else result = 1;
                            break;
                        }

                    case 4:
                        {
                            num_B = (num_b - 1) % 2;
                            if (num_B == 0) result = 4;
                            else result = 6;
                            break;
                        }

                    case 5:
                        {
                            result = 5;
                            break;
                        }

                    case 6:
                        {
                            result = 6;
                            break;
                        }

                    case 7:
                        {
                            num_B = (num_b - 1) % 4;
                            if (num_B == 0) result = 7;
                            else if (num_B == 1) result = 9;
                            else if (num_B == 2) result = 3;
                            else result = 1;
                            break;
                        }

                    case 8:
                        {
                            num_B = (num_b - 1) % 4;
                            if (num_B == 0) result = 8;
                            else if (num_B == 1) result = 4;
                            else if (num_B == 2) result = 2;
                            else result = 6;
                            break;
                        }

                    case 9:
                        {
                            num_B = num_b % 2;
                            if (num_B == 0) result = 1;
                            else if (num_B == 1) result = 9;
                            break;
                        }

                    default: Console.WriteLine("Error"); 
                        break;
                }
                Console.WriteLine(result);
            }
        }
    }