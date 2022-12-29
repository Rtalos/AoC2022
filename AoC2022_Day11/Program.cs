
using AoC2022_Day11;
using System.Diagnostics;
using System.Text.RegularExpressions;

var stopwatch = Stopwatch.StartNew();

var input = System.IO.File.ReadAllLines(@"input.txt");

var monkeys = Generator.CreateMonkeys(input);

var factor = monkeys
    .Select(m => m.Test)
    .Aggregate((f1, f2) => f1 * f2);

for (int i = 0; i < 20; i++)
{
    foreach (var monkey in monkeys)
    {
        monkey.PerformOperation();
    }
}

stopwatch.Stop();

var top = monkeys.Select(x => x.Inspection).OrderByDescending(x => x).Take(2);

Console.WriteLine(top.Aggregate((l, r) => l * r));

Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");
