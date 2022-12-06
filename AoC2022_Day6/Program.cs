using AoC2022_Day6;

var sequence = Input.sequence;

var chars = sequence.ToCharArray().ToList();
var skip = 0;
var markerLength = 14;
while (true)
{
    if (chars.Skip(skip).Take(markerLength).Distinct().Count() == markerLength)
        break;
    skip++;
}
Console.WriteLine(skip + markerLength);