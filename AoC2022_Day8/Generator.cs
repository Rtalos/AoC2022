using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day8
{
    public static class Generate
    {
        public static int[,] Forest(string[] input)
        {
            int[,] forest = new int[input[0].Length, input[0].Length];

            for (int i = 0; i < input.Length; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                {
                    var tree = input[i].ToCharArray()[j];
                    forest[i, j] = int.Parse(tree.ToString());
                }
            }

            return forest;
        }
    }
}
