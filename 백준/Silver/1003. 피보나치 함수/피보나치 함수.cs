using System;
using System.Collections.Generic;

namespace fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> fibonacci_List = new List<int>(); //피보나치 수열을 리스트화

            fibonacci_List.Add(0);
            fibonacci_List.Add(1);//기본값 2개 넣어놓고
            int basenum = fibonacci_List.Count;

            for (int i = 0; i < 40 - basenum + 1; i++) // N이 주어지는데. N은 40보다 작거나 같은 자연수 또는 0이다. 기본값 2개 넣어뒀으니 40 - basenum + 1
            {
                fibonacci_List.Add(fibonacci_List[fibonacci_List.Count-1] + fibonacci_List[fibonacci_List.Count - 2]);
            }


            List<int> testcases = new List<int>();

            int testcase = int.Parse(Console.ReadLine());//케이스 횟수


            for (int i = 0; i < testcase; i++)
            {
                testcases.Add(int.Parse(Console.ReadLine()));//케이스 값 리스트에 넣기
            }

            int zero_result;
            int one_result;

            void fibonacci(int a)
            {
                zero_result = 0;
                one_result = 0;
                switch (a)
                {
                    case 0:
                        {
                            zero_result = 1;
                            break;
                        }
                    case 1:
                        {
                            one_result = 1;
                            break;
                        }
                    default:
                        {
                            zero_result = fibonacci_List[a - 1];
                            one_result = fibonacci_List[a];
                            break;
                        }
                }
            }

            for (int i = 0; i < testcases.Count; i++)//리스트에서 빼면서 연산
            {
                fibonacci(testcases[i]);
                Console.WriteLine($"{zero_result} {one_result}");
            }
        }
    }
}
