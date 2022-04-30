
using System.Diagnostics;
using System.Threading;

class MultiThreadSort : RankSort
{
    static void PlaceItem(int[] arr, int start, int end)
    {
        try
        {
            // Console.WriteLine("{0}, {1}", start, end);
            for (int i = start; i < end; i++)
            {
                int rank = GetRank(arr, arr[i]);
                sorted[rank] = arr[i];
            }
        }
        catch (ThreadAbortException ex)
        {
            // Console.WriteLine("Thread is aborted");
        }
    }
    public static string Execute(int[] arr)
    {
        // HelperFunctions.PrintArray(arr);
        Stopwatch timer = new Stopwatch();
        timer.Start();

        sorted = Enumerable.Repeat(-1, arr.Length).ToArray();
        int start = 0;
        int end = arr.Length - 1;
        int mid = arr.Length / 2;

        Thread childThread1 = new Thread(() => PlaceItem(arr, start, mid));
        Thread childThread2 = new Thread(() => PlaceItem(arr, mid, end));

        childThread1.Start();
        childThread2.Start();

        childThread1.Join();
        childThread2.Join();

        childThread1.Interrupt();
        childThread2.Interrupt();
        // HelperFunctions.PrintArray(sorted);

        timer.Stop();
        return timer.Elapsed.TotalMilliseconds.ToString();
    }
}