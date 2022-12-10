namespace AoC2022_Day10;

internal class Printer
{
    private List<int> _printingSequences = new List<int>();
    private List<string> _printOutput = new List<string>();

    private int _pixelPosition;

    private string _lit = "\u2588";
    private string _dark = "\u0020";

    public Printer(List<int> printingSequences)
    {
        _printingSequences.AddRange(printingSequences);
    }

    public List<string> Print()
    {
        // currentRegister is sprite position
        var currentRegister = 1;
        foreach (var addx in _printingSequences.Skip(1))
        {
            var cycles = addx == 0 ? 1 : 2;
            for (int i = 0; i < cycles; i++)
            {
                var pixel = (_pixelPosition == (currentRegister - 1) || _pixelPosition == currentRegister || _pixelPosition == (currentRegister + 1)) ? _lit : _dark;
                _pixelPosition++;

                if (_pixelPosition == 40)
                    _pixelPosition = 0;

                _printOutput.Add(pixel);
            }
            currentRegister += addx;
        }

        return FixPrint(_printOutput);
    }

    private List<string> FixPrint(List<string> printOutput)
    {
        for (int i = 0; i < 6; i++)
        {
            printOutput.Insert((40*i)+i, Environment.NewLine);
        }

        return printOutput;
    }
}

