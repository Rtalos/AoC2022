﻿public class Monkey
{
    public int Number { get; set; }
    public long Inspection { get; set; }
    public Queue<long> StartingItems { get; set; } = new Queue<long>();
    public Func<long, long> Operation { get; set; }
    public int Test { get; set; }
    public Monkey Monkey1 { get; set; }
    public Monkey Monkey2 { get; set; }

    public Monkey(int number)
    {
        Number = number;
    }

    public void PerformOperation(long lcm = 0)
    {
        while (StartingItems.Any())
        {
            var item = StartingItems.Dequeue();
            var worryLevel = Operation(item);
            worryLevel = lcm == 0 ? (long)Math.Floor(worryLevel / 3d) : worryLevel % lcm;
            var list = new List<long> { worryLevel };

            if (worryLevel % Test == 0)
            {
                Monkey1.AddItems(list);
            }
            else
                Monkey2.AddItems(list);

            Inspection++;
        }
    }

    public void SetOperation(string op, string value)
    {
        var func = op == "+" 
            ? new Func<long, long>((long old) => old + (int.TryParse(value, out var v) ? v : old)) 
            : new Func<long, long>((long old) => old * (int.TryParse(value, out var v) ? v : old));

        Operation = func;
    }

    public void AddItems(IEnumerable<long> items)
    {
        foreach (var item in items)
        {
            StartingItems.Enqueue(item);
        }
    }
}