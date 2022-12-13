namespace AoC2022_Day8;

public class Tree
{
    private int height;
    private bool visible;
    private (int x, int y) index;

    public Tree((int x, int y) index, int heiglht)
    {
        this.height = heiglht;
        this.index = index;
    }

    public int Height { get => height; set => height = value; }
    public bool Visible { get => visible; set => visible = value; }
    public (int x, int y) Index { get => index; set => index = value; }
}
