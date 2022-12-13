using AoC2022_Day8;
using System.Diagnostics;

var input = System.IO.File.ReadAllLines(@"input.txt");

var stopWatch = Stopwatch.StartNew();

var forest = Generate.Forest(input);

var count = Peeper.CountTrees(forest);

stopWatch.Stop();

Console.WriteLine(count);
Console.WriteLine($"Time to run all: {stopWatch.Elapsed.Milliseconds} ms");
