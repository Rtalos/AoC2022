using AoC2022_Day8;
using static AoC2022_Day8.Enums;

var input = System.IO.File.ReadAllLines(@"input.txt");

var forest = Generate.Forest(input);

var count = Peeper.CountTrees(forest);

Console.WriteLine(count);