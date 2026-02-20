using System;

namespace _20260220_bronze
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(); // 총인원수,
                                                         // X대학 A배율,
                                                         // Y대학 B배율,
                                                         // Z대학 C배율,
                                                         // D = AX + BY + CZ
                                                         // X대학 E배율,
                                                         // Y대학 F배율,
                                                         // Z대학 G배율,
                                                         // H = EX + FY + GZ

            long total = int.Parse(input[0]);
            long A = int.Parse(input[1]);
            long B = int.Parse(input[2]);
            long C = int.Parse(input[3]);
            long D = int.Parse(input[4]);
            long E = int.Parse(input[5]);
            long F = int.Parse(input[6]);
            long G = int.Parse(input[7]);
            long H = int.Parse(input[8]);

            bool has_anwser = false;
            bool duplication = false;

            long X = 0;
            long Y = 0;
            long Z_temp = 0;
            long Z = 0;

            for (int i = 0; i <= total; i++)//X
            {
                for (int j = 0; j <= total - i; j++)//Y
                {
                    //나머지는 Z
                    Z_temp = total - i - j;

                    if ((i + j + Z_temp) == total)
                    {
                        if (
                            ((i * A) + (j * B) + (Z_temp * C))==D) 
                        {
                            if(
                                ((i * E) + (j * F) + (Z_temp * G))==H)
                            {
                                if (has_anwser)
                                {
                                    duplication = true;
                                    break;
                                }
                                else if (!has_anwser)
                                {
                                    X = i;
                                    Y = j;
                                    Z = Z_temp;
                                    has_anwser = true;
                                }
                            }
                        }
                    }
                }
                if (duplication) { break; }
            }

            if (!has_anwser)
            {
                Console.WriteLine(2);
            }
            else if (duplication)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
                Console.WriteLine($"{X} {Y} {Z}");
            }
        }
    }
}
