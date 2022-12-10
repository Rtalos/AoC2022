using AoC2022_Day8;
using static AoC2022_Day8.Enums;

var input = System.IO.File.ReadAllLines(@"testinput.txt");

var forest = Generate.Forest(input);

// 99 + 98 + 98 + 97

//var a = Peeper.Peep(forest).CountTrees();

var count = Peeper.CountTrees(forest);

Console.WriteLine(count);

var a =
@"
  0  3037313
  1  2XX1213
  2  6X33213
  3  33X4XX0
  4  3X3X001
  5  0000001
  6  1234567     

     0123456

     3037313
     2551213
     6533213
     3354910
     3539001
     0000001
     1234567
";

//24 runt + 8 + 32