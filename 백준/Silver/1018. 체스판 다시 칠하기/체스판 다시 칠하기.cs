using System;
using System.Collections.Generic;

namespace _20260219_silver
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int vert = int.Parse(input[0]);
            int hori = int.Parse(input[1]);

            List<List<bool>> board = new List<List<bool>>(); //2중 리스트 csv할때 했던거(그땐 이중 dictionary)

            for (int i = 0; i < vert; i++) //세로 갯수만큼
            {
                board.Add(new List<bool>());
            }

            for (int i = 0; i < vert; i++)//세로
            {
                char[] input_BW = Console.ReadLine().ToCharArray(); //char로 쪼갬
                for (int j = 0; j < hori; j++) //가로
                {
                    if (input_BW[j].Equals('W'))//White = true로 설정
                    {
                        board[i].Add(true);
                    }
                    else
                    {
                        board[i].Add(false);
                    }
                }
            }

            //이중 리스트에 담아버림
            //-----------------------------

            int min_total = int.MaxValue;

            for (int i = 0; i <= vert - 8; i++)//세로
            {
                for (int j = 0; j <= hori - 8; j++)//가로
                {
                    int paint_count = 0;
                    bool cross = true; // 시작할 때마다 기준색 초기화 (W 시작 기준)

                    // 8줄을 내려감
                    for (int x = i; x < i + 8; x++)
                    {
                        for (int y = j; y < j + 8; y++)
                        {
                            // 현재 칸 색깔이 기준색(cross)과 다르면 카운트
                            if (board[x][y] != cross) paint_count++;

                            // 옆칸으로 가니까 반전
                            cross = !cross;
                        }
                        // 한 줄(8칸) 다 봤으면 다음 줄 시작색은 윗줄 시작색과 달라야 함
                        cross = !cross;
                    }

                    // 한 사각형(64칸) 다 셌으면 결과 비교
                    int min_temp = Math.Min(paint_count, 64 - paint_count);//검정 아니면 흰색이니 64에서 빼버림
                    if (min_temp < min_total) min_total = min_temp;
                }
            }
            Console.WriteLine(min_total);
        }
    }
}
