using AoC2022_Day5;
using System.Linq;

var instructions = Input.instructions;

var onlyForVisualization = @"

                [V]     [C]     [M]
[V]     [J]     [N]     [H]     [V]
[R] [F] [N]     [W]     [Z]     [N]
[H] [R] [D]     [Q] [M] [L]     [B]
[B] [C] [H] [V] [R] [C] [G]     [R]
[G] [G] [F] [S] [D] [H] [B] [R] [S]
[D] [N] [S] [D] [H] [G] [J] [J] [G]
[W] [J] [L] [J] [S] [P] [F] [S] [L]

";

// Part 1
var stacks = new List<Stack<char>>
{
    new Stack<char>(new char[] { 'W', 'D', 'G', 'B', 'H', 'R', 'V' }),
    new Stack<char>(new char[] { 'J', 'N', 'G', 'C', 'R', 'F' }),
    new Stack<char>(new char[] { 'L', 'S', 'F', 'H', 'D', 'N', 'J' }),
    new Stack<char>(new char[] { 'J', 'D', 'S', 'V' }),
    new Stack<char>(new char[] { 'S', 'H', 'D', 'R', 'Q', 'W', 'N', 'V' }),
    new Stack<char>(new char[] { 'P', 'G', 'H', 'C', 'M' }),
    new Stack<char>(new char[] { 'F', 'J', 'B', 'G', 'L', 'Z', 'H', 'C' }),
    new Stack<char>(new char[] { 'S', 'J', 'R' }),
    new Stack<char>(new char[] { 'L', 'G', 'S', 'R', 'B', 'N', 'V', 'M' })
};

foreach (var procedure in instructions)
{
    var fromStack = stacks.ElementAt(procedure.from - 1);
    var toStack = stacks.ElementAt(procedure.to - 1);

    for (int i = 0; i < procedure.move; i++)
    {
        toStack.Push(fromStack.Pop());
    }
}

var top = stacks.Select(x => x.Pop().ToString());

Console.WriteLine(String.Join("", top));

// Part 2
var stableStacks = new List<List<char>>
{
    new List<char> { 'W', 'D', 'G', 'B', 'H', 'R', 'V' },
    new List<char> { 'J', 'N', 'G', 'C', 'R', 'F' },
    new List<char> { 'L', 'S', 'F', 'H', 'D', 'N', 'J' },
    new List<char> { 'J', 'D', 'S', 'V' },
    new List<char> { 'S', 'H', 'D', 'R', 'Q', 'W', 'N', 'V' },
    new List<char> { 'P', 'G', 'H', 'C', 'M' },
    new List<char> { 'F', 'J', 'B', 'G', 'L', 'Z', 'H', 'C' },
    new List<char> { 'S', 'J', 'R' },
    new List<char> { 'L', 'G', 'S', 'R', 'B', 'N', 'V', 'M' }
};

foreach (var procedure in instructions)
{
    var fromStack = stableStacks.ElementAt(procedure.from - 1);
    var toStack = stableStacks.ElementAt(procedure.to - 1);

    var crates = fromStack.TakeLast(procedure.move).ToList();

    fromStack.RemoveRange(fromStack.Count() - procedure.move, procedure.move);

    toStack.AddRange(crates);

}

var topStable = stableStacks.Select(x => x.Last().ToString());

Console.WriteLine(String.Join("", topStable));
