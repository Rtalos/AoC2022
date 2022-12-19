using AoC2022_Day12;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var vertices = Generator.CreateVertices();

var shortestPath = BreadthFirstSearch.Search(vertices.ToList(), vertices.First(v => v.Data == 'S'));

Console.WriteLine(shortestPath.Count());

//Rough P2, needs optimization
var stackPathP2 = new List<Stack<Vertex<char>>>();
var verticesP2 = vertices.Where(v => v.Data == 'a');
foreach (var vertex in verticesP2)
{
    var shortestPathP2 = BreadthFirstSearch.Search(vertices.ToList(), vertex);
    stackPathP2.Add(shortestPathP2);
}

stackPathP2.RemoveAll(x => x.Count == 0);

var b = stackPathP2.MinBy(x => x.Count);

stopwatch.Stop();

Console.WriteLine(b.Count);
Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");

//Work in progress to get visualization oging
//CreateHeightMap(shortestPath);

//foreach (var item in shortestPath)
//{
//    Console.WriteLine($"Index: {item.Index} - {item.Data}");
//}

