using AoC2022_Day12;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var vertices = Generator.CreateVertices();

var shortestPathAscending = BreadthFirstSearch.SearchAscend(vertices.ToList(), 'S', 'E');
var shortestPathDescending = BreadthFirstSearch.SearchDescend(vertices.ToList(), 'E', 'a');

Console.WriteLine(shortestPathAscending.Count());
Console.WriteLine(shortestPathDescending.Count());

stopwatch.Stop();

Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");
