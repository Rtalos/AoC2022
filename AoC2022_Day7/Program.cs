using AoC2022_Day7;

var cmdList = Input.CliInput.Split(Environment.NewLine).ToList();
var rootNode = new Node(directoryName: "/");

ExecuteCLIArguments(rootNode, cmdList);

var sizes = new Dictionary<Node, long>();
CalculateTotalDirectorySizes(rootNode, sizes);


var directorySizes = sizes.Values.Where(size => size <= 100_000).Sum();

var directoryToDeleteFullSize = sizes.Values.OrderBy(size => Math.Abs(size - (30_000_000 - (70_000_000 - sizes.Values.Max())))).First();

Console.WriteLine(directorySizes);
Console.WriteLine(directoryToDeleteFullSize);


void CalculateTotalDirectorySizes(Node dir, Dictionary<Node, long> sizes)
{
    long size = 0;
    foreach (var child in dir.SubDirectories)
    {
        if (!child.SubDirectories.Any())
        {
            size += child.Size;
            sizes.Add(child, child.Size);
        }
        else
        {
            CalculateTotalDirectorySizes(child, sizes);
            size += sizes[child];
        }
    }
    sizes[dir] = size + dir.Size;
}

static void ExecuteCLIArguments(Node rootNode, List<string> input)
{
    var currentNode = rootNode;

    foreach (var cmd in input)
    {
        if (Split(cmd, out _).Any(x => x == "ls"))
            continue;

        if (Split(cmd, out _).Any(x => x == "/"))
        {
            currentNode = rootNode;
        }
        else if (Split(cmd, out _).Any(x => x == ".."))
        {
            currentNode = currentNode.ParentNode;
        }
        else if (Split(cmd, out var strings1).Any(x => x == "cd"))
        {
            currentNode = currentNode.SubDirectories.First(x => x.DirectoryName == strings1[2]);
        }

        var num = 0;
        if (Split(cmd, out _).Any(x => int.TryParse(x, out num)))
        {
            currentNode.Size += num;
        }

        if (Split(cmd, out var strings2).Any(x => x == "dir"))
        {
            var subNode = new Node();

            subNode.DirectoryName = strings2[1];
            subNode.ParentNode = currentNode;
            currentNode.SubDirectories.Add(subNode);
        }
    }
}

static string[] Split(string cmd, out string[] strings)
{
    strings = cmd.Split(" ");
    return strings;
}

public class Node
{
    public Node ParentNode { get; set; }
    public string DirectoryName { get; set; } = string.Empty;
    public int Size { get; set; }
    public List<Node> SubDirectories { get; set; } = new List<Node>();

    public Node(string directoryName = "", int size = 0)
    {
        DirectoryName = directoryName;
        Size = size;
    }
}