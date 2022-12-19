namespace AoC2022_Day12;

public static class Generator
{
    public static IEnumerable<Vertex<char>> CreateVertices()
    {
        var input = System.IO.File.ReadAllLines(@"input.txt");

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                var node = input[i].ToCharArray()[j];

                yield return new Vertex<char>((i, j), node);
            }
        }
    }

    public static void CreateHeightMap(IEnumerable<Vertex<char>> shortestPath)
    {
        var input = System.IO.File.ReadAllLines(@"testinput.txt");

        char[,] heightMap = new char[input.Length, input[0].Length];

        for (int i = 0; i < input.Length; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                var position = input[i].ToCharArray()[j];

                var vertex = shortestPath.FirstOrDefault(t => t.Index == (i, j));

                if (vertex != null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{vertex.Data}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{position}");
                }
            }

            Console.Write(Environment.NewLine);
        }
    }
}

