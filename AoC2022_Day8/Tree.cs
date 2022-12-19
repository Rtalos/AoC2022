namespace AoC2022_Day8;

public class Tree
{
    private int height;
    private bool visible;
    private (int x, int y) index;
    private List<int> visibleNeighbours = new List<int>();

    public Tree((int x, int y) index, int heiglht)
    {
        this.height = heiglht;
        this.index = index;
    }

    public int Height { get => height; set => height = value; }
    public bool Visible { get => visible; set => visible = value; }
    public List<int> VisibleNeighbours { set => visibleNeighbours = value; }
    public (int x, int y) Index { get => index; set => index = value; }

    public int GetSceneryScore()
    {
        return visibleNeighbours.Aggregate((l, r) => l * r);
    }
}
