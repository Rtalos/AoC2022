using AoC2022_Day10;

var input = File.ReadAllLines(@"input.txt");

var processingUnit = new ProcessingUnit();

foreach (var pixel in processingUnit.Process(input).StartPrinting())
{
    Console.Write(pixel);
}



