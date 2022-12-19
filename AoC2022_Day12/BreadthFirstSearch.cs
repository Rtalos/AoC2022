namespace AoC2022_Day12;

public static class BreadthFirstSearch
{
    public static Stack<Vertex<char>> Search(List<Vertex<char>> vertices, Vertex<char> startVertex)
    {
        Queue<Vertex<char>> queue = new Queue<Vertex<char>>();

        if (startVertex.Data == 'S')
        {
            startVertex.Start = 'S';
            startVertex.Data = 'a';
        }
 
        var endVertex = vertices.First(v => v.Data == 'E');
        endVertex.Data = 'z';
        endVertex.End = 'E';

        queue.Enqueue(startVertex);

        startVertex.Visit();

        while (queue.Count > 0)
        {
            var currentVertex = queue.Dequeue();

            if (currentVertex.Equals(endVertex))
            {
                var path = Backtrack(startVertex, currentVertex);
                return path;
            }

            var leftNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column - 1));
            var rightNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column + 1));
            var topNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row - 1, currentVertex.Index.column));
            var bottomNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row + 1, currentVertex.Index.column));

            if (leftNeighbour != null && !leftNeighbour.Visited)
            {
                //currentVertex.Neighbours.Add(leftNeighbour);

                if (currentVertex.Data == leftNeighbour.Data
                    || currentVertex.Data + 1 == leftNeighbour.Data
                    || currentVertex.Data > leftNeighbour.Data)
                {
                    leftNeighbour.Visit();
                    leftNeighbour.ParentVertex = currentVertex;
                    queue.Enqueue(leftNeighbour);
                }
            }

            if (rightNeighbour != null && !rightNeighbour.Visited)
            {
                //currentVertex.Neighbours.Add(rightNeighbour);

                if (currentVertex.Data == rightNeighbour.Data
                   || currentVertex.Data + 1 == rightNeighbour.Data
                   || currentVertex.Data > rightNeighbour.Data)
                {
                    rightNeighbour.Visit();
                    rightNeighbour.ParentVertex = currentVertex;
                    queue.Enqueue(rightNeighbour);
                }
            }

            if (topNeighbour != null && !topNeighbour.Visited)
            {
                //currentVertex.Neighbours.Add(topNeighbour);

                if (currentVertex.Data == topNeighbour.Data
                   || currentVertex.Data + 1 == topNeighbour.Data
                   || currentVertex.Data > topNeighbour.Data)
                {
                    topNeighbour.Visit();
                    topNeighbour.ParentVertex = currentVertex;
                    queue.Enqueue(topNeighbour);
                }
            }

            if (bottomNeighbour != null && !bottomNeighbour.Visited)
            {
                //currentVertex.Neighbours.Add(bottomNeighbour);

                if (currentVertex.Data == bottomNeighbour.Data
                   || currentVertex.Data + 1 == bottomNeighbour.Data
                   || currentVertex.Data > bottomNeighbour.Data)
                {
                    bottomNeighbour.Visit();
                    bottomNeighbour.ParentVertex = currentVertex;
                    queue.Enqueue(bottomNeighbour);
                }
            }
        }

        return new Stack<Vertex<char>>();
    }

    public static Stack<Vertex<char>> Backtrack(Vertex<char> startVertex, Vertex<char> endVertex)
    {
        var path = new Stack<Vertex<char>>();

        var currentVertex = endVertex;

        path.Push(endVertex);

        while (currentVertex!.ParentVertex != startVertex)
        {
            path.Push(currentVertex!.ParentVertex!);
            currentVertex = currentVertex.ParentVertex;
        }

        return path;
    }
}

