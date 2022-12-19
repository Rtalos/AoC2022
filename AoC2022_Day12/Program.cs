using AoC2022_Day12;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var vertices = Generator.CreateVertices();

var shortestPath = BreadthFirstSearch.Search(vertices.ToList());

Console.WriteLine(shortestPath.Count());

stopwatch.Stop();

Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");

//Work in progress to get visualization oging
//CreateHeightMap(shortestPath);

//foreach (var item in shortestPath)
//{
//    Console.WriteLine($"Index: {item.Index} - {item.Data}");
//}

