
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

//Stopwatch sw = new Stopwatch();
//sw.Start();
//var reader = new StreamReader(@"input.txt");
//const int ROUNDS = 10000;
//List<MonkeyA> monkeys = new List<MonkeyA>();
//MonkeyA currentMonkey = new MonkeyA();
//while (!reader?.EndOfStream ?? false)
//{
//var line = reader?.ReadLine()?.Trim().Split(':', ' ', ',');
//if (line.Length == 1) continue;
//switch ((line?[0], line?[1]))
//{
//case ("Monkey", _): currentMonkey = new MonkeyA(); break;
//case ("Starting", _): currentMonkey.items = new Queue<long>(line[2..].Select(x => long.TryParse(x, out long xInt) ? xInt : -1).Where(x => x > -1)); break;
//case ("Operation", _):
//currentMonkey.operation = line[line.Length - 2] switch
//{
//"+" => x => x + (long.TryParse(line[line.Length - 1], out long a) ? a : x),
//"-" => x => x - (long.TryParse(line[line.Length - 1], out long a) ? a : x),
//"*" => x => x * (long.TryParse(line[line.Length - 1], out long a) ? a : x),
//"/" => x => x / (long.TryParse(line[line.Length - 1], out long a) ? a : x),
//_ => x => x
//}; break;
//case ("Test", _): currentMonkey.test = x => x % (long.TryParse(line[line.Length - 1], out long a) ? a : x) == 0; break;
//case ("If", "true"): currentMonkey.TrueMonkey = int.TryParse(line[line.Length - 1], out int t) ? t : -1; break;
//case ("If", "false"): currentMonkey.FalseMonkey = int.TryParse(line[line.Length - 1], out int f) ? f : -1; monkeys.Add(currentMonkey); break;
//default: break;
//}
//}
//foreach (var _ in Enumerable.Range(0, ROUNDS))
//{
//foreach (var monkey in monkeys)
//{
//while (monkey.items.TryDequeue(out long worryLevel))
//{
//worryLevel = monkey.operation!(worryLevel);
//worryLevel %= 9699690; //Got a hint about LCM for this line :)
//                       // worryLevel=(long)Math.Floor(worryLevel/3d);
//if (monkey.test!(worryLevel))
//{
//monkeys[monkey.TrueMonkey].items.Enqueue(worryLevel);
//}
//else
//{
//monkeys[monkey.FalseMonkey].items.Enqueue(worryLevel);
//}
//monkey.numberOfInspections++;
//}
//}
//}
//var topTwoBusiestMonkeys = new List<MonkeyA>(monkeys.OrderByDescending(m => m.numberOfInspections).Take(2));
//var monkeyBusiness = topTwoBusiestMonkeys![0].numberOfInspections * topTwoBusiestMonkeys![1].numberOfInspections;
//reader?.Dispose();
//sw.Stop();
//Console.WriteLine($"\nPart 1: {monkeyBusiness}");
//Console.WriteLine($"Executed in {sw.Elapsed.TotalMilliseconds} ms.");

//class MonkeyA
//{
//    public Queue<long> items = new Queue<long>();
//    public Func<long, long>? operation;
//    public Predicate<long>? test;
//    public int TrueMonkey;
//    public int FalseMonkey;
//    public long numberOfInspections = 0;
//}
