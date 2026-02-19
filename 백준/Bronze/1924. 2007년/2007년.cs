using System;

namespace _20260219_bronze
{
    class Program
    {
        static void Main(string[] args)
        {
            int month = 0;
            int day = 0;
            int month_to_day = 0;
            int result_day = 0;

            string[] input = Console.ReadLine().Split();
            month = int.Parse(input[0]) ;
            day = int.Parse(input[1]);

            for (int i = 0; i < month; i++) //0이 1월. 12월은 추가하지 않습니다.
            {
                //달에 일수는 같고, 경우가 많은것 부터 체크
                if (i.Equals(1) || //2월엔 1월꺼 추가
                    i.Equals(3) || //4월엔 3월꺼 추가
                    i.Equals(5) || //6월엔 5월꺼 추가
                    i.Equals(7) || //8월엔 7월꺼 추가
                    i.Equals(8) || //9월엔 8월꺼 추가
                    i.Equals(10))  //11월엔 10월꺼 추가
                {
                    month_to_day += 31;
                }
                else if (i.Equals(2)) // 3월은 2월꺼 추가
                {
                    month_to_day += 28;
                }
                else if (i.Equals(0))//1월은 스킵
                {
                    continue;
                }
                else//나머지 4, 6, 9, 11월
                {
                    month_to_day += 30;
                }
            }

            result_day = (month_to_day + day) % 7;

            switch (result_day)
            {
                case 0:
                    {
                        Console.WriteLine("SUN");
                        break;
                    }
                case 1:
                    {
                        Console.WriteLine("MON");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("TUE");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("WED");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("THU");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("FRI");
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("SAT");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Error");
                    }
                    break;
            }
        }
    }
}
