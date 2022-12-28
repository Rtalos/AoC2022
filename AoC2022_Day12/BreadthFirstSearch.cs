namespace AoC2022_Day12;

public static class BreadthFirstSearch
{
    public static Stack<Vertex<char>> SearchAscend(List<Vertex<char>> vertices, char start, char end)
    {
        return Search(vertices, start, end, Order.Ascending);
    }

    public static Stack<Vertex<char>> SearchDescend(List<Vertex<char>> vertices, char start, char end)
    {
        return Search(vertices, start, end, Order.Descending);
    }

    private static Stack<Vertex<char>> Search(List<Vertex<char>> vertices, char start, char end, Order order)
    {
        var queue = new Queue<Vertex<char>>();

        var startVertex = vertices.First(v => v.Data == start);

        queue.Enqueue(startVertex);

        startVertex.Visit();

        while (queue.Any())
        {
            var currentVertex = queue.Dequeue();

            if (currentVertex.Data == end)
            {
                var fullPath = BacktrackPath(startVertex, currentVertex);
                return fullPath;
            }

            var leftNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column - 1));
            var rightNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row, currentVertex.Index.column + 1));
            var topNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row - 1, currentVertex.Index.column));
            var bottomNeighbour = vertices.FirstOrDefault(v => v.Index == (currentVertex.Index.row + 1, currentVertex.Index.column));

            ApplyConditions(queue, currentVertex, leftNeighbour, order);
            ApplyConditions(queue, currentVertex, rightNeighbour, order);
            ApplyConditions(queue, currentVertex, topNeighbour, order);
            ApplyConditions(queue, currentVertex, bottomNeighbour, order);
        }

        return new Stack<Vertex<char>>();
    }

    private static void ApplyConditions(Queue<Vertex<char>> queue, Vertex<char> currentVertex, Vertex<char>? vertex, Order order)
    {
        if (vertex != null && !vertex.Visited)
        {
            //currentVertex.Neighbours.Add(vertex);

            if (Condition(order, currentVertex, vertex))
            {
                vertex.Visit();
                vertex.ParentVertex = currentVertex;
                queue.Enqueue(vertex);
            }
        }
    }

    private static bool Condition(Order order, Vertex<char> currentVertex, Vertex<char> vertex) => order switch
    {
        Order.Ascending => (vertex.Data == 'E' 
                            || currentVertex.Data == 'S'
                            || currentVertex.Data + 1 >= vertex.Data),
        Order.Descending => (vertex.Data == 'S'
                            || currentVertex.Data - 1 <= vertex.Data),
        _ => false
    };

    private static Stack<Vertex<char>> BacktrackPath(Vertex<char> startVertex, Vertex<char> endVertex)
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

    private enum Order
    {
        Ascending,
        Descending
    }
}

