namespace AoC2022_Day11;

public static class Generator
{
    public static IEnumerable<Monkey> CreateMonkeys(string[] input)
    {
        var s = new Queue<string>(input);

        var monkeys = Generator.CreateMonkeys().ToList();

        while (s.Any())
        {
            var l = s.Dequeue();

            if (l.Contains("Monkey"))
            {
                var lines = s.Dequeue(5);
                var monkey = monkeys.First(x => x.Number == int.Parse(StringHelper.Split(l)[1].Trim(':')));

                foreach (var instruction in lines)
                {
                    if (instruction.Contains("Starting items:"))
                    {
                        var items = StringHelper.Split(instruction.TrimStart(' ')).Skip(2).ToArray();

                        var a = Enumerable.Range(0, items.Count()).Select((v, i) => long.Parse(items[i].Trim(',')));

                        monkey.AddItems(a);
                    }

                    if (instruction.Contains("Operation:"))
                    {
                        var items = StringHelper.Split(instruction.TrimStart(' ')).Skip(4).ToArray();
                        monkey.SetOperation(items[0], items[1]);
                    }

                    if (instruction.Contains("Test:"))
                    {
                        var items = StringHelper.Split(instruction.TrimStart(' ')).Skip(3).ToArray();
                        monkey.Test = int.Parse(items[0]);
                    }

                    if (instruction.Contains("true"))
                    {
                        var items = StringHelper.Split(instruction.TrimStart(' ')).Skip(5).ToArray();
                        monkey.Monkey1 = monkeys.First(m => m.Number == int.Parse(items[0]));
                    }

                    if (instruction.Contains("false"))
                    {
                        var items = StringHelper.Split(instruction.TrimStart(' ')).Skip(5).ToArray();
                        monkey.Monkey2 = monkeys.First(m => m.Number == int.Parse(items[0]));
                    }
                }
            }
        }

        return monkeys;
    }

    private static IEnumerable<Monkey> CreateMonkeys()
    {
        for (int i = 0; i < 8; i++)
        {
            yield return new Monkey(i);
        }
    }
}

