using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day10;

internal class ProcessingUnit
{
    private Dictionary<int, List<int>> _thresholdSequences = new Dictionary<int, List<int>>();
    private List<int> _processedAddXOperations = new List<int>();
    private int _tick;

    public Dictionary<int, List<int>> ThresholdSequences => _thresholdSequences;

    public ProcessingUnit()
    {
        //Add starter op 1
        _processedAddXOperations.Add(1);
    }

    public ProcessingUnit Process(string[] input)
    {
        //TODO see to possibly better this
        foreach (var line in input)
        {
            var splitInstruction = StringHelper.Split(line);
            if (splitInstruction.Any(x => x == "addx"))
            {
                foreach (var cycle in splitInstruction)
                {
                    _tick++;
                    CheckForSignalThreshold();
                    if (int.TryParse(cycle, out var value))
                    {
                        _processedAddXOperations.Add(int.Parse(splitInstruction[1]));
                    }
                }
                continue;
            }

            if (splitInstruction.Any(x => x == "noop"))
            {
                _tick++;
                CheckForSignalThreshold();

                _processedAddXOperations.Add(0);
            }

        }
        return this;
    }

    public List<string> StartPrinting()
    {
        var printer = new Printer(_processedAddXOperations);

        return printer.Print();
    }

    public int CalculateThresholdRange()
    {
        //TODO see if LINQ can solve this
        var total = 0;
        foreach (var op in _thresholdSequences)
        {
            total += op.Value.Sum() * op.Key;
        }
        return total;
    }

    private void CheckForSignalThreshold()
    {
        if (InternalThreshold(_tick).reached)
        {
            //Pass new list and not ref to keep range
            _thresholdSequences.Add(_tick, _processedAddXOperations.ToList());
        }
    }

    private (bool reached, int threshold) InternalThreshold(int tick) => tick switch
    {
        40 => (true, 40),
        80 => (true, 80),
        120 => (true, 120),
        160 => (true, 160),
        200 => (true, 200),
        240 => (true, 240),
        _ => (false, 0)
    };
}

