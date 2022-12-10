using AoC2022_Day10;

var input = File.ReadAllLines(@"input.txt");

var processingUnit = new ProcessingUnit();

Console.WriteLine(processingUnit.Process(input).CalculateThresholdRange());
