namespace AoC2022_Day8;

public static class Peeper
{
    public static int CountTrees(int[,] forest)
    {
        //height is the same with this grid
        var width = forest.GetLength(0);

        var visibleTrees = new List<(int x, int y, bool visible)>();

        var allRows = GetAllRowsAndIndices2(forest);
        var allColumns = GetAllColumnsAndIndices2(forest);

        visibleTrees.AddRange(FindVisibleTrees(allRows, width));
        visibleTrees.AddRange(FindVisibleTrees(allRows.Reverse(), width));
        visibleTrees.AddRange(FindVisibleTrees(allColumns, width));
        visibleTrees.AddRange(FindVisibleTrees(allColumns.Reverse(), width));

        //var a = FindNeighbours(allRows, width);

        //VisualDebugging(forest, visibleTrees);

        return visibleTrees.Distinct().Count();
    }

    private static void VisualDebugging(int[,] forest, IEnumerable<(int x, int y, bool visible)> visibleTrees)
    {
        var trees = Generate.ForestYield().ToList();

        foreach (var visibleTree in visibleTrees)
        {
            trees.First(t => t.Index == (visibleTree.x, visibleTree.y)).Visible = true;
        }

        // Visual debugging tool
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
    }

    private static IEnumerable<(int x, int y, bool visible)> FindVisibleTrees(IEnumerable<(int x, int y, int height)> collection, int gridMax)
    {
        var highestTree = 0;

        foreach (var tuple in collection)
        {
            if (tuple.height > highestTree || (tuple.y == 0 || tuple.x == 0) || (tuple.y == (gridMax - 1) || tuple.x == (gridMax - 1)))
            {
                highestTree = tuple.height;
                yield return (tuple.x, tuple.y, true);
            }
        }
    }

    //Experimental ==NOT WORKING==
    private static IEnumerable<(int x, int y, List<int> neighbours)> FindNeighbours(IEnumerable<(int x, int y, int height)> collection, int gridMax)
    {
        var highestTree = 0;
        var internalMax = gridMax;
        var intlist = new List<int>();
        var list = new List<(int x, int y, List<int> neighbours)>();

        foreach (var tuple in collection)
        {
            internalMax--;

            if (tuple.height >= highestTree || (tuple.y == 0 || tuple.x == 0) || (tuple.y == (gridMax - 1) || tuple.x == (gridMax - 1)))
            {
                var previousNeighbourHeight = 0;
                var range = collection.Take(internalMax).ToList();

                foreach (var neighbours in range)
                {
                    if (neighbours.height >= tuple.height)
                    {
                        previousNeighbourHeight = neighbours.height;
                        intlist.Add(1);
                    }
                }
            }

            list.Add((tuple.x, tuple.y, intlist));
            intlist.Clear();
        }

        return list;
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

    private static IEnumerable<(int x, int y, int height)> GetAllRowsAndIndices2(int[,] matrix)
    {
        for (int x = 0; x < matrix.GetLength(0); x++)
        {
            for (int y = 0; y < matrix.GetLength(1); y++)
            {
                yield return (x, y, matrix[x, y]);
            }
        }
    }

    private static IEnumerable<(int x, int y, int height)> GetAllColumnsAndIndices2(int[,] matrix)
    {
        for (int y = 0; y < matrix.GetLength(0); y++)
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                yield return (x, y, matrix[x, y]);
            }
        }
    }

    //private static List<int> GetColumn(int[,] matrix, int columnNumber)
    //{
    //    return Enumerable.Range(0, matrix.GetLength(0))
    //            .Select(x => matrix[x, columnNumber])
    //            .ToList();
    //}


    //private static List<int> GetRow(int[,] matrix, int rowNumber)
    //{
    //    return Enumerable.Range(0, matrix.GetLength(1))
    //            .Select(x => matrix[rowNumber, x])
    //            .ToList();
    //}
}


