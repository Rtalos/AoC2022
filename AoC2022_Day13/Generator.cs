using System.Text.Json;

namespace AoC2022_Day13;

public class Generator
{
    private string _text = "";
    private string[] _pairs = new string[0];

    public string Text { set => _text = value; }

    public Generator(string text)
    {
        Text = text;
        CreatePairs();
    }

    public IEnumerable<(int index, bool correctOrder, JsonElement left, JsonElement right)> CreatePackets()
    {
        for (int i = 0; i < _pairs.Length; i++)
        {
            var split = StringHelper.Split(_pairs[i], "\r\n");

            yield return (i + 1, false, JsonDocument.Parse(split[0]).RootElement, JsonDocument.Parse(split[1]).RootElement);
        }
    }

    public IEnumerable<(int index, JsonElement element)> CreateSinglePackets()
    {
        var singlesText = _pairs.SelectMany(x => StringHelper.Split(x, "\r\n")).ToList();

        for (int i = 0; i < singlesText.Count; i++)
        {
            yield return (i + 1, JsonDocument.Parse(singlesText[i]).RootElement);
        }
    }

    private void CreatePairs()
    {
        _pairs = StringHelper.Split(_text, "\r\n\r\n");
    }
}

