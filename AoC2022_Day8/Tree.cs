using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day8
{
    public class Tree
    {
        public int Height { get; set; }
        public bool Visible { get; set; }
        public (int x, int y) Index { get; set; }
    }
}