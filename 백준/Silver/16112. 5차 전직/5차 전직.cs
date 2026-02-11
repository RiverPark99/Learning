class Program
    {
        static void Main(string[] args)
        {
            //int Quest = 0;
            int Stone = 0;

            List<long> ex_num = new List<long>(); //경험치 량
            List<long> Stone_ex = new List<long>();//스톤에 저장된 경험치

            long result = 0;

            string[] input = Console.ReadLine().Split();

            //Quest = int.Parse(input[0]);
            Stone = int.Parse(input[1]);

            string[] string_ex = Console.ReadLine().Split();

            for (int i = 0; i < Stone; i++)
            {
                Stone_ex.Add(0);
            }

            for (int i = 0; i < string_ex.Length; i++)
            {
                ex_num.Add(int.Parse(string_ex[i]));
                
            }//list 화 완료

            ex_num.Sort();

            int getstone = 0;

            for (int i = 0; i < ex_num.Count; i++)//활성화 시킨 돌의 갯수만큼
            {
                result += (ex_num[i] * getstone);
                if (getstone < Stone)
                {
                    getstone += 1;
                }
            }

            Console.WriteLine(result);

        }
    }