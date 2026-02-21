using System;
using System.Collections.Generic;

namespace _20260221_sliver
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int classrooms = int.Parse(input[0]);
            int query = int.Parse(input[1]);

            List<List<int>> list = new List<List<int>>(); //층, 반으로 2중 자료구조

            for (int i = 0; i < 4; i++)//층은 총4개
            {
                list.Add(new List<int>()); //층별로 리스트 추가

                for (int j = 0; j < classrooms; j++)
                {
                    list[i].Add(0);// i반, 초기 공사영향은 0
                }
            }

            List<int> query2_answer = new List<int>();

            for (int i = 0; i < query; i++) //쿼리 실행
            {
                string[] input_query = Console.ReadLine().Split();
                int query_1or2= int.Parse(input_query[0]);
                int force_floor = int.Parse(input_query[1])-1; // 1빼줘야됌. 1층->0번 인덱스
                int force_classroom = 0;

                if (query_1or2.Equals(1)) // query_1or2 중 2면 2 index 존재하지 않음
                {
                    force_classroom = int.Parse(input_query[2])-1;// 1빼줘야됌. 1반->0번 인덱스
                }

                if (query_1or2.Equals(2))
                {
                    int query_anwser = 0;
                    int best_force = -1;// 쿼리문 한번에 바로 2때려버리면 0도 잡아야됌
                    for (int j = 0; j < classrooms; j++)//해당 층 검사
                    {
                        if (best_force < list[force_floor][j])
                        {
                            best_force = list[force_floor][j];
                            query_anwser = j;
                        }
                    }
                    query2_answer.Add(query_anwser+1); //0번부터 인데 1반부터있음
                }
                else//force주기
                {
                    //해당 반 +1
                    list[force_floor][force_classroom] += 1;

                    //공사반에 붙어있는 반 +1씩
                    if (force_classroom > 0)  //최 좌측이 아니면
                    { 
                        list[force_floor][force_classroom - 1] += 1; 
                    }

                    if (force_classroom < classrooms - 1) //최 우측이 아니면
                    { 
                        list[force_floor][force_classroom + 1] += 1; 
                    }

                    switch (force_floor)
                    {
                        case 0: // 1층일 때
                            list[1][force_classroom] += 1; // 2층에 영향 (인덱스 1)
                            break;
                        case 3: // 4층일 때
                            list[2][force_classroom] += 1; // 3층에 영향 (인덱스 2)
                            break;
                        default: // 2, 3층일 때
                            list[force_floor + 1][force_classroom] += 1;
                            list[force_floor - 1][force_classroom] += 1;
                            break;
                    }
                }
            }

            for (int i = 0; i < query2_answer.Count; i++)
            {
                Console.WriteLine(query2_answer[i]);
            }

            // 오량반 층수, 반 번호
            
            int result_folor = 0;
            int result_classroom = 0;
            int best_forcenum = -1;
            for (int i = 0; i < 4; i++)//전체 검사합니다.
            {
                for (int j = 0; j < classrooms; j++)
                {
                    if(list[i][j]> best_forcenum)
                    {
                        best_forcenum = list[i][j];
                        result_folor = i;
                        result_classroom = j;
                    }
                }
            }
            Console.WriteLine($"{result_folor+1} {result_classroom+1}");//리스트는0부터 시작인데 반과 층은 0이 없음
        }
    }
}
