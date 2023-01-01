using System.Text.Json;

namespace AoC2022_Day13;

public static class PacketHelper
{
    public static IEnumerable<int> StartComparing(List<(int index, bool correctOrder, JsonElement left, JsonElement right)> packets)
    {
        foreach (var packet in packets)
        {
            var correctOrder = PacketHelper.Compare(packet.index, packet.left, packet.right) < 0;

            if (correctOrder)
            {
                yield return packet.index;
            }
        }
    }

    public static void Sort(List<(int index, JsonElement element)> packets, int left, int right)
    {
        int pivot;
        if (left < right)
        {
            pivot = Partition(packets, left, right);
            if (pivot > 1)
            {
                Sort(packets, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Sort(packets, pivot + 1, right);
            }
        }
    }

    public static void AddDecoderPackets(List<(int index, JsonElement element)> singlePackets)
    {
        singlePackets.Add((1000, JsonDocument.Parse("[[2]]").RootElement));
        singlePackets.Add((1001, JsonDocument.Parse("[[6]]").RootElement));
    }

    private static int Compare(int index, JsonElement left, JsonElement right)
    {
        var leftArrayLength = left.GetArrayLength();
        var rightArrayLength = right.GetArrayLength();
        int returnValue = 0;
        var broken = false;

        for (int i = 0; i < leftArrayLength; i++)
        {
            if (i >= rightArrayLength)
                return 1;

            if (left[i].ValueKind == JsonValueKind.Number && right[i].ValueKind == JsonValueKind.Number)
            {
                returnValue = left[i].GetInt32() - right[i].GetInt32();
            }

            if (left[i].ValueKind == JsonValueKind.Array && right[i].ValueKind == JsonValueKind.Number)
            {
                returnValue = Compare(index, left[i], JsonDocument.Parse($"[{right[i]}]").RootElement);
            }

            if (left[i].ValueKind == JsonValueKind.Number && right[i].ValueKind == JsonValueKind.Array)
            {
                returnValue = Compare(index, JsonDocument.Parse($"[{left[i]}]").RootElement, right[i]);
            }

            if (left[i].ValueKind == JsonValueKind.Array && right[i].ValueKind == JsonValueKind.Array)
            {
                returnValue = Compare(index, left[i], right[i]);
            }

            if (returnValue == 0)
                continue;
            else
            {
                broken = true;
                break;
            }
        }

        if (((leftArrayLength == 0 && rightArrayLength != 0) || returnValue < 0) && broken || (!broken && leftArrayLength < rightArrayLength))
            return -1;

        return Math.Sign(returnValue);
    }

    private static int Partition(List<(int index, JsonElement element)> packets, int left, int right)
    {
        var pivot = packets[left];
        while (true)
        {
            while (Compare(pivot.index, pivot.element, packets[left].element) == 1)
            {
                left++;
            }

            while (Compare(pivot.index, pivot.element, packets[right].element) == -1)
            {
                right--;
            }

            if (left < right)
            {
                var temp = packets[right];
                packets[right] = packets[left];
                packets[left] = temp;
            }
            else
            {
                return right;
            }
        }

    }
}

