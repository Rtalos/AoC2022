using AoC2022_Day2;

// Part 1
// A = Rock
// B = Paper
// C = Scissor
// X = Rock
// Y = Paper
// Z = Scissor
//static int Outcome((string, string) strat) => strat switch
//{
//    ("A", "X") => 4,
//    ("A", "Y") => 8,
//    ("A", "Z") => 3,
//    ("B", "X") => 1,
//    ("B", "Y") => 5,
//    ("B", "Z") => 9,
//    ("C", "X") => 7,
//    ("C", "Y") => 2,
//    ("C", "Z") => 6,
//    _ => throw new ArgumentOutOfRangeException(nameof(strat), $"Not expected direction value: {strat}"),
//};


// Part 2
// A = Rock
// B = Paper
// C = Scissor
// X = Loss
// Y = Draw
// Z = Win

static int Outcome((string, string) strat) => strat switch
{
    ("A", "X") => 3,
    ("A", "Y") => 4,
    ("A", "Z") => 8,
    ("B", "X") => 1,
    ("B", "Y") => 5,
    ("B", "Z") => 9,
    ("C", "X") => 2,
    ("C", "Y") => 6,
    ("C", "Z") => 7,
    _ => throw new ArgumentOutOfRangeException(nameof(strat), $"Poopers: {strat}"),
};

var result = new List<int>();
foreach (var turn in Input.strategy)
{
    result.Add(Outcome(turn));
}

Console.WriteLine(result.Sum());
