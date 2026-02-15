using System;
using System.Collections.Generic;

namespace _17952
{
    class Program
    {
        class assignment//커스텀 자료형
        {
            public int Havetodo;
            public int Score;
            public int Require_time;

            public assignment(int havetodo, int score, int requiretime)
            {
                Havetodo = havetodo;
                Score = score;
                Require_time = requiretime;
            }
        }

        static void Main(string[] args)
        {
            List<assignment> assignments = new List<assignment>();// 현재 과제 정보
            Stack<int> doingindex = new Stack<int>();//선입 후출, 남은 과제 처리하기 위한 List index용 자료구조 사용
            int doing_now_index = 0;//현재 진행중인 과제는?
            bool isdoing = false; //과제중인가?
            int result = 0;//결과

            int fulltime = int.Parse(Console.ReadLine());//전체 주어진 시간

            for (int i = 0; i < fulltime; i++)
            {
                string[] input = Console.ReadLine().Split();
                if (int.Parse(input[0]).Equals(1))// 1이면 과제 있음 string받고있으니 확인
                {
                    assignment newinfo = new assignment(int.Parse(input[0]), int.Parse(input[1]), int.Parse(input[2]));
                    assignments.Add(newinfo);
                }
                else//0이면 과제 없음
                {
                    assignment newinfo = new assignment(0, 0, 0);
                    assignments.Add(newinfo);
                }
            } //리스트에 현재 과제 정보 집어넣기 완료
            
            //-------------------------------------------------------------

            for (int i = 0; i < fulltime; i++)
            {
                if (assignments[i].Havetodo.Equals(0))//과제 없음
                {
                    if (!isdoing) { continue; }//하고있는 과제가 없으면 넘기기

                    assignments[doing_now_index].Require_time -= 1;

                    if (assignments[doing_now_index].Require_time.Equals(0))
                    {
                        result += assignments[doing_now_index].Score;

                        if (doingindex.Count.Equals(0))//남아있는 과제가 없다면
                        {
                            isdoing = false;
                        }
                        else//과제가 남아있다면
                        {
                            doing_now_index = doingindex.Pop();//남아있는거 꺼내서 숙제시작
                        }
                    }
                }
                else//과제 줬음
                {
                    if (isdoing)//이미 하고있던중이였다면
                    {
                        doingindex.Push(doing_now_index);//하던거 stack에 미루기
                    }
                    isdoing = true;
                    doing_now_index = i;

                    assignments[doing_now_index].Require_time -= 1;

                    if (assignments[doing_now_index].Require_time.Equals(0))
                    {
                        result += assignments[doing_now_index].Score;

                        if (doingindex.Count.Equals(0))//남아있는 과제가 없다면
                        {
                            isdoing = false;
                        }
                        else//과제가 남아있다면
                        {
                            doing_now_index = doingindex.Pop();//남아있는거 꺼내서 숙제시작
                        }
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}
