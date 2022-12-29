using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var input = System.IO.File.ReadAllLines(@"testinput.txt");

var rope = new Rope(input).Start();
var brokenRope = new Rope(input, new (int x, int y)[10]).Start();

stopwatch.Stop();

Console.WriteLine(rope.VisitedTailCoordinate.Count());
Console.WriteLine(brokenRope.VisitedTailCoordinate.Count());

Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");
