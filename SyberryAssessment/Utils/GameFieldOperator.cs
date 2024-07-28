using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyberryAssessment.Utils
{
    internal static class GameFieldOperator
    {
        public static void ParseData(string input, out string[] lines)
        {
            lines = input.Split('_');
        }

        public static void SetDimensions(string[] lines, out int m, out int n)
        {
            m = lines.Length;
            n = lines[0].Length;
        }

        public static void LoadGameField(int m, int n, string[] lines, int[,] universe, int[,] newUniverse)
        {
            char[] cellArray;

            // load the game field
            for (int i = 1; i <= m; i++)
            {
                cellArray = lines[i - 1].ToCharArray();
                for (int j = 1; j <= n; j++)
                {
                    if (cellArray[j - 1] == '1')
                    {
                        universe[i, j] += 1;
                        newUniverse[i, j] += 1;
                    }
                }
            }
        }

        public static void PerformGameIteration(int[,] universe, int[,] newUniverse, int m, int n)
        {
            // game cycle
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    int liveCells = universe[i - 1, j - 1] + universe[i - 1, j] + universe[i - 1, j + 1] +
                          universe[i, j - 1] + universe[i, j + 1] +
                          universe[i + 1, j - 1] + universe[i + 1, j] + universe[i + 1, j + 1];

                    // if cell is now alive
                    if (universe[i, j] == 1)
                    {
                        if (liveCells < 2 || liveCells > 3)
                        {
                            newUniverse[i, j] = 0;
                        }
                    }
                    else
                    {  // cell now is dead
                        if (liveCells == 3)
                        {
                            newUniverse[i, j] = 1;
                        }
                    }
                }
            }
        }

        public static void FormAnswer(int[,] newUniverse, int m, int n, out string answer)
        {
            answer = "";

            for (int i = 1; i <= m; i++)
            {
                if (!string.IsNullOrEmpty(answer))
                    answer += "_";
                for (int j = 1; j <= n; j++)
                {
                    answer += newUniverse[i, j];
                }
            }
        }
    }
}
