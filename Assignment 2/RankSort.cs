
using System.Diagnostics;
using System.Threading;
class RankSort
{
    static protected int[] sorted;
    static protected int GetRank(int[] arr, int value)
    {
        int rank = 0;
        foreach (var item in arr)
        {
            if (item < value)
                rank++;
        }
        // if index already occupied, find the next one
        while (sorted[rank] != -1)
        {
            rank++;
            rank %= arr.Length;
        }
        return rank;
    }
}

