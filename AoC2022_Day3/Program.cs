using AoC2022_Day3;

static int Priorities(char item) => item switch
{
    'a' => 1,
    'b' => 2,
    'c' => 3,
    'd' => 4,
    'e' => 5,
    'f' => 6,
    'g' => 7,
    'h' => 8,
    'i' => 9,
    'j' => 10,
    'k' => 11,
    'l' => 12,
    'm' => 13,
    'n' => 14,
    'o' => 15,
    'p' => 16,
    'q' => 17,
    'r' => 18,
    's' => 19,
    't' => 20,
    'u' => 21,
    'v' => 22,
    'w' => 23,
    'x' => 24,
    'y' => 25,
    'z' => 26,
    'A' => 27,
    'B' => 28,
    'C' => 29,
    'D' => 30,
    'E' => 31,
    'F' => 32,
    'G' => 33,
    'H' => 34,
    'I' => 35,
    'J' => 36,
    'K' => 37,
    'L' => 38,
    'M' => 39,
    'N' => 40,
    'O' => 41,
    'P' => 42,
    'Q' => 43,
    'R' => 44,
    'S' => 45,
    'T' => 46,
    'U' => 47,
    'V' => 48,
    'W' => 49,
    'X' => 50,
    'Y' => 51,
    'Z' => 52,
    _ => throw new ArgumentOutOfRangeException(nameof(item), $"Poopers: {item}"),
};

//var result = 0;

//foreach (var rucksack in Input.rucksacks)
//{
//    var chars = rucksack.ToCharArray();
//    var firstCompartment = chars.Take(chars.Length / 2);
//    var secondCompartment = chars.Skip(chars.Length / 2);

//    var foundDuplicates = firstCompartment.Intersect(secondCompartment);

//    result += Priorities(foundDuplicates.Single());
//}



var badgePrio = 0;
while (Input.rucksacks.Any())
{
    var group = Input.rucksacks.Take(3);

    var rucksack1 = group.ElementAt(0);
    var rucksack2 = group.ElementAt(1);
    var rucksack3 = group.ElementAt(2);

    var first = rucksack1.Intersect(rucksack2);

    var final = first.Intersect(rucksack3);

    Char badge;
    foreach (var item in final)
    {
        var firstCheck = rucksack1.Any(x => x == item);
        var secondCheck = rucksack2.Any(x => x == item);
        var thirdCheck = rucksack3.Any(x => x == item);

        if (firstCheck && secondCheck && thirdCheck)
            badge = item;
        break;
    }

    badgePrio += Priorities(final.First());

    Input.rucksacks.RemoveRange(0, 3);
}


Console.WriteLine(badgePrio);