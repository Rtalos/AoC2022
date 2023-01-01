
using AoC2022_Day11;
using System.Diagnostics;
using System.Text.RegularExpressions;

var stopwatch = Stopwatch.StartNew();

var input = System.IO.File.ReadAllLines(@"input.txt");

var monkeys = Generator.CreateMonkeys(input);

// Part 1
//for (int i = 0; i < 20; i++)
//{
//    foreach (var monkey in monkeys)
//    {
//        monkey.PerformOperation();
//    }
//}

//var top = monkeys.Select(x => x.Inspection).OrderByDescending(x => x).Take(2);

//Console.WriteLine(top.Aggregate((l, r) => l * r));

var primes = monkeys.Select(m => m.Test).Where(p => p != 0).ToList();
var lcm = primes.Aggregate((l, r) => l * r);

// Part 2
for (int i = 0; i < 10_000; i++)
{
    foreach (var monkey in monkeys)
    {
        monkey.PerformOperation(lcm);
    }
}

stopwatch.Stop();

var top2 = monkeys.Select(x => x.Inspection)
                      .OrderByDescending(x => x)
                      .Take(2)
                      .Aggregate((l, r) => l * r);

Console.WriteLine(top2);

Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");
