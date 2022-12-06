using AoC2022_Day4;

var sectionPairs = Input.sectionPairs;
var result = 0;

//while (sectionPairs.Any())
//{
//    var pair = sectionPairs.Take(2);

//    var firstElf = pair.ElementAt(0);
//    var secondElf = pair.ElementAt(1);

//    var firstRange = Enumerable.Range(firstElf.Item1, firstElf.Item2 - firstElf.Item1 + 1);
//    var secondRange = Enumerable.Range(secondElf.Item1, secondElf.Item2 - secondElf.Item1 + 1);

//    var discrepancy = firstRange.Count() <= secondRange.Count() ? firstRange.Except(secondRange) : secondRange.Except(firstRange);

//    if (!discrepancy.Any())
//    {
//        result++;
//    }

//    sectionPairs.RemoveRange(0, 2);
//}

while (sectionPairs.Any())
{
    var pair = sectionPairs.Take(2);

    var firstElf = pair.ElementAt(0);
    var secondElf = pair.ElementAt(1);

    var firstSection = Enumerable.Range(firstElf.Item1, firstElf.Item2 - firstElf.Item1 + 1);
    var secondSection = Enumerable.Range(secondElf.Item1, secondElf.Item2 - secondElf.Item1 + 1);

    var overlaps = secondSection.Intersect(firstSection);

    if (overlaps.Any())
    {
        result++;
    }

    sectionPairs.RemoveRange(0, 2);
}

Console.WriteLine(result);