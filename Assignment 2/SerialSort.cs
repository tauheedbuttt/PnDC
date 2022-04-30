
using System.Diagnostics;
using System.Threading;
class SerialSort : RankSort
{
    public static string Execute(int[] arr)
    {
        Stopwatch timer = new Stopwatch();
        // new memory for sorted elements. each empty space represented by -1
        sorted = Enumerable.Repeat(-1, arr.Length).ToArray();
        timer.Start();

        foreach (var item in arr)
        {
            int rank = GetRank(arr, item);
            sorted[rank] = item;
        }

        timer.Stop();
        return timer.Elapsed.TotalMilliseconds.ToString();
    }
}

