using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day11;

internal class StringHelper
{
    public static string[] Split(string instruction)
    {
        var strings = instruction.Split(" ");
        return strings;
    }
}
