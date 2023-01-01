using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day13;

public static class StringHelper
{
    public static string[] Split(string value, string splitOn)
    {
        var strings = value.Split(splitOn);
        return strings;
    }
}

