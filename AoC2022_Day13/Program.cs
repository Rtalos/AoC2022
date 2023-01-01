using AoC2022_Day13;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

var stopwatch = Stopwatch.StartNew();


var text = File.ReadAllText(@"input.txt");

var generator = new Generator(text);

var packets = generator.CreatePackets().ToList();

var sumOfIndices = PacketHelper.StartComparing(packets).ToList().Sum();

var singlePackets = generator.CreateSinglePackets().ToList();

PacketHelper.AddDecoderPackets(singlePackets);

PacketHelper.Sort(singlePackets, 0, singlePackets.Count-1);

var firstDecoderPack = singlePackets.FirstOrDefault(x => x.index == 1000);
var secondDecoderPack = singlePackets.FirstOrDefault(x => x.index == 1001);

var firstDecoderPackIndex = singlePackets.IndexOf(firstDecoderPack) + 1;
var secondDecoderPackIndex = singlePackets.IndexOf(secondDecoderPack) + 1;


stopwatch.Stop();

Console.WriteLine(sumOfIndices);
Console.WriteLine(firstDecoderPackIndex * secondDecoderPackIndex);
Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.Milliseconds} ms");