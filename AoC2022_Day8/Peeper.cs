using System.Linq;
using static AoC2022_Day8.Enums;

namespace AoC2022_Day8;

public static class Peeper
{
    public static int CountTrees(int[,] forest)
    {
        var visibleTrees = 0;
        var width = forest.GetLength(0);
        var height = forest.GetLength(1);

        var rows = new List<IEnumerable<(int, int, int)>>();
        var columns = new List<IEnumerable<(int, int, int)>>();

        for (int i = 0; i < width; i++)
        {
            rows.Add(GetRowAndIndices(forest, i));
            columns.Add(GetColumnAndIndices(forest, i));
        }

        var trees = new List<Tree>();
        var a = trees.OrderBy(x => x.Index).Select(y => y.Index);
        var b = trees.Where(x => x.Visible);

        IterateCollections(rows, trees);
        IterateCollections(rows, trees, Direction.Reverse);
        IterateCollections(columns, trees);
        IterateCollections(columns, trees, Direction.Reverse);


        for (int x = 0; x < forest.GetLength(0); x++)
        {
            for (int y = 0; y < forest.GetLength(1); y++)
            {
                var tree = trees.First(t => t.Index == (x, y));
                if (tree.Visible)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"{tree.Height}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write($"{tree.Height}");
                }
            }

            Console.Write(Environment.NewLine);
        }

        Console.WriteLine(b.Count());

        return visibleTrees;
    }

    private static void IterateCollections(List<IEnumerable<(int x, int y, int height)>> collection, List<Tree> trees, Direction direction = Direction.Forward)
    {
        foreach (var item in collection)
        {
            var placeholderlist = new List<(int x, int y, int height)>();
            placeholderlist.AddRange(item);
            if (direction == Direction.Reverse)
                placeholderlist.Reverse();

            var highestTree = 0;

            foreach (var tuple in placeholderlist)
            {
                var tree = !trees.Any(x => x.Index == (tuple.x, tuple.y)) ? CreateTree(trees, tuple) : trees.First(x => x.Index == (tuple.x, tuple.y));

                if (trees.Any(x => x.Index == (tuple.x, tuple.y) && x.Visible))
                {
                    highestTree = tuple.height;
                    continue;
                }
                    
                if (tuple.height > highestTree || (tuple.y == 0 || tuple.x == 0))
                {
                    tree.Visible = true;
                    highestTree = tuple.height;
                }
            }
        }
    }

    private static Tree CreateTree(List<Tree> trees, (int x, int y, int height) tuple)
    {
        var tree = new Tree();
        tree.Height = tuple.height;
        tree.Visited = true;
        tree.Index = (tuple.x, tuple.y);
        trees.Add(tree);
        return tree;
    }

    private static List<int> GetColumn(int[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                .Select(x => matrix[x, columnNumber])
                .ToList();
    }


    private static List<int> GetRow(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToList();
    }

    private static IEnumerable<(int x, int y, int height)> GetColumnAndIndices(int[,] matrix, int columnNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(0))
                                               .Select(x => (x, columnNumber, matrix[x, columnNumber]));
     
    }

    private static IEnumerable<(int x, int y, int height)> GetRowAndIndices(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => (rowNumber, x, matrix[rowNumber, x]));
    }

    private enum Direction
    {
        Forward,
        Reverse
    }
}


