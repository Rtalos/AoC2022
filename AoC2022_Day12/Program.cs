using AoC2022_Day12;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var vertices = Generator.CreateVertices();

var shortestPath = BreadthFirstSearch.Search(vertices.ToList(), vertices.First(v => v.Data == 'S'));

Console.WriteLine(shortestPath.Count());

//Small optimization, could need redesign for P2
var stackPathP2 = new List<int>();
var verticesP2 = vertices.Where(v => v.Data == 'a');

Parallel.ForEach(verticesP2, vertex =>
{
    var shortestPathP2 = BreadthFirstSearch.SearchSimplified(vertices.ToList(), vertex);
    stackPathP2.Add(shortestPathP2);
});

stackPathP2.RemoveAll(x => x == 0);

var minimumNoOfVertices = stackPathP2.MinBy(x => x);

stopwatch.Stop();

Console.WriteLine(minimumNoOfVertices);
Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");

//Work in progress to get visualization oging
//CreateHeightMap(shortestPath);

//foreach (var item in shortestPath)
//{
//    Console.WriteLine($"Index: {item.Index} - {item.Data}");
//}

