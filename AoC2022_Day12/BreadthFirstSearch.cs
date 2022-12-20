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
                var fullPath = BacktrackFullPathInformation(startVertex, currentVertex);
                return fullPath;
            }

            var leftNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column - 1));
            var rightNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column + 1));
            var topNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row - 1, currentVertex.Index.column));
            var bottomNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row + 1, currentVertex.Index.column));

            ApplyConditions(queue, currentVertex, leftNeighbour);
            ApplyConditions(queue, currentVertex, rightNeighbour);
            ApplyConditions(queue, currentVertex, topNeighbour);
            ApplyConditions(queue, currentVertex, bottomNeighbour);
        }

        return new Stack<Vertex<char>>();
    }

    public static int SearchSimplified(List<Vertex<char>> vertices, Vertex<char> startVertex)
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
                var numberOfVerticesInPath = BacktrackSimplified(startVertex, currentVertex);
                return numberOfVerticesInPath;
            }

            var leftNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column - 1));
            var rightNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column + 1));
            var topNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row - 1, currentVertex.Index.column));
            var bottomNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row + 1, currentVertex.Index.column));

            ApplyConditions(queue, currentVertex, leftNeighbour);
            ApplyConditions(queue, currentVertex, rightNeighbour);
            ApplyConditions(queue, currentVertex, topNeighbour);
            ApplyConditions(queue, currentVertex, bottomNeighbour);
        }

        return 0;
    }

    private static void ApplyConditions(Queue<Vertex<char>> queue, Vertex<char> currentVertex, Vertex<char>? vertex)
    {
        if (vertex != null && !vertex.Visited)
        {
            //currentVertex.Neighbours.Add(vertex);

            if (currentVertex.Data == vertex.Data
                || currentVertex.Data + 1 == vertex.Data
                || currentVertex.Data > vertex.Data)
            {
                vertex.Visit();
                vertex.ParentVertex = currentVertex;
                queue.Enqueue(vertex);
            }
        }
    }

    private static Stack<Vertex<char>> BacktrackFullPathInformation(Vertex<char> startVertex, Vertex<char> endVertex)
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

    private static int BacktrackSimplified(Vertex<char> startVertex, Vertex<char> endVertex)
    {
        var counter = 0;

        var currentVertex = endVertex;

        counter++;

        while (currentVertex!.ParentVertex != startVertex)
        {
            counter++;
            currentVertex = currentVertex.ParentVertex;
        }

        return counter;
    }
}

