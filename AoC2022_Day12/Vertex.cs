public class Vertex<T>
{
    private (int x, int y) _index;
    //private List<Vertex<T>> _neighbours = new List<Vertex<T>>();
    private bool _visited;
    private T _data;
    private T? _start;
    private T? _end;
    private Vertex<T>? parentVertex;

    public (int row, int column) Index { get => _index; set => _index = value; }
    public Vertex<T>? ParentVertex { get => parentVertex; set => parentVertex = value; }
    //public List<Vertex<T>> Neighbours { get => _neighbours; set => _neighbours = value; }
    public T Data { get => _data; set => _data = value; }
    public T? Start { get => _start; set => _start = value; }
    public T? End { get => _end; set => _end = value; }
    public bool Visited { get => _visited; set => _visited = value; }

    public Vertex((int x, int y) index, T data)
    {
        _data = data;
        _index = index;
    }

    public void Visit() => _visited = true;
}