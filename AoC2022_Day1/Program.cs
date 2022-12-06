using AoC2022_Day1;

var listlist = new List<Dictionary<int, int>>();
var innerDic = new Dictionary<int, int>();
var innerList = new List<int>();

var elf = 0;
foreach (var item in Input.list)
{
    if (item == 0)
    {
        innerDic.Add(elf, innerList.Sum());
        innerList.Clear();
        elf++;
    }

    innerList.Add(item);
}

listlist.Add(innerDic);

Console.WriteLine(listlist.First().Values.OrderByDescending(x => x).Take(3).Sum());
Console.WriteLine(listlist.First().Values.Max());