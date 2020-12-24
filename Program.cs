using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConquestCampaign(3, 4, 2, new int[] { 2, 2, 3, 4 }));
            Console.ReadKey();
        }
        static int ConquestCampaign(int N, int M, int L, int[] battalion)
        {
            int count = 1;
            if (N * M > L)
                count += 1;
            int[,] arr = new int[N, M];

            for (int i = 0; i < battalion.Length - 1; i = i+2)
            {
                    arr[battalion[i] - 1, battalion[i + 1] - 1] = 1;
            }

            bool b = true;

            while (b)
            {
                b = false;

                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (arr[i, j] != 0)
                            arr[i, j] += 1;

                    }

                }
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (((i + 1) < N) && (arr[i, j] >= 2))
                            arr[i + 1, j] += 1;
                        if (((i - 1) >= 0) && (arr[i, j] >= 2))
                            arr[i - 1, j] += 1;
                        if (((j + 1) < M) && (arr[i, j] >= 2))
                            arr[i, j + 1] += 1;
                        if (((j - 1) >= 0) && (arr[i, j] >= 2))
                            arr[i, j - 1] += 1;
                    }
                }
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++)
                    {
                        if (arr[i, j] == 0)
                        {
                            count += 1;
                            i = N;
                            b = true;
                            break;
                        }

                    }
                }
            }
            return count;
        }
    }
}
