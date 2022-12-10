using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022_Day10
{
    internal class ProcessingUnit
    {
        private Dictionary<int, List<int>> ThresholdRanges = new Dictionary<int, List<int>>();
        private List<int> ProcessedAddXOperations = new List<int>();
        public ProcessingUnit()
        {
            //Add starter op 1
            ProcessedAddXOperations.Add(1);
        }
        public int Tick { get; set; }
        public void CheckForSignalThreshold()
        {
            if (InternalThreshold(Tick).reached)
            {
                //Pass new list and not ref to keep range
                ThresholdRanges.Add(Tick, ProcessedAddXOperations.ToList());
            }
        }
        public (bool reached, int threshold) InternalThreshold(int tick) => tick switch
        {
            20 => (true, 20),
            60 => (true, 20),
            100 => (true, 20),
            140 => (true, 20),
            180 => (true, 20),
            220 => (true, 20),
            _ => (false, 0)
        };
        public ProcessingUnit Process(string[] input)
        {
            foreach (var line in input)
            {
                var splitInstruction = StringHelper.Split(line);
                if (splitInstruction.Any(x => x == "addx"))
                {
                    foreach (var cycle in splitInstruction)
                    {
                        Tick++;
                        CheckForSignalThreshold();
                        if (int.TryParse(cycle, out var value))
                        {
                            ProcessedAddXOperations.Add(int.Parse(splitInstruction[1]));
                        }
                    }
                    continue;
                }
                Tick++;
                CheckForSignalThreshold();
                Console.WriteLine(line);
            }
            return this;
        }
        public int CalculateThresholdRange()
        {
            //TODO see if LINQ can solve this
            var total = 0;
            foreach (var op in ThresholdRanges)
            {
                total += op.Value.Sum() * op.Key;
            }
            return total;
        }
    }
}
