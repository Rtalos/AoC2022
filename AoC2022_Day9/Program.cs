using AoC2022_Day9;
using System.Diagnostics;

var stopwatch = Stopwatch.StartNew();

var input = System.IO.File.ReadAllLines(@"input.txt");

var rope = new Rope(input).Start();
var brokenRope = new Rope(input, new (int x, int y)[10]).Start();

stopwatch.Stop();

Console.WriteLine(rope.VisitedTailCoordinate.Count());
Console.WriteLine(brokenRope.VisitedTailCoordinate.Count());
Console.WriteLine($"{stopwatch.Elapsed.Milliseconds} ms");

class Rope
{
    private (int x, int y) coordinate = (0, 0);
    private HashSet<(int x, int y)> visitedCoordinates = new HashSet<(int x, int y)>();

    public (int x, int y)[] Parts { get; set; } = new (int x, int y)[2];
    public (int x, int y) Coordinate { get => coordinate; set => coordinate = value; }
    public HashSet<(int x, int y)> VisitedTailCoordinate { get => visitedCoordinates; set => visitedCoordinates = value; }
    public string[] Input { get; set; }

    public Rope(string[] input, (int x, int y)[] parts)
    {
        Input = input;
        Parts = parts;
    }

    public Rope(string[] input)
    {
        Input = input;
    }

    public Rope Start()
    {
        foreach (var line in Input)
        {
            var splitLine = StringHelper.Split(line);

            for (int i = 0; i < int.Parse(splitLine[1]); i++)
            {
                Parts[0] = CalculateMovement(splitLine[0], Parts[0]);

                CalculateTailpath();

                Visit();
            }
        }

        return this;
    }

    private void Visit() => VisitedTailCoordinate.Add(Parts.Last());

    private void CalculateTailpath()
    {
        for (var j = 1; j < Parts.Length; j++)
        {
            var (previousX, previousY) = Parts[j - 1];
            var (currentX, currentY) = Parts[j];
            var dX = previousX - currentX;
            var dY = previousY - currentY;

            if (Math.Abs(dX) > 1 || Math.Abs(dY) > 1)
            {
                Parts[j].x += Math.Sign(dX);
                Parts[j].y += Math.Sign(dY);
            }
        }
    }

    private static (int x, int y) CalculateMovement(string direction, (int x, int y) coordinate) => direction switch
    {
        "R" => (coordinate.x + 1, coordinate.y),
        "L" => (coordinate.x - 1, coordinate.y),
        "U" => (coordinate.x, coordinate.y + 1),
        "D" => (coordinate.x, coordinate.y - 1),
        _ => (0, 0)
    };
}