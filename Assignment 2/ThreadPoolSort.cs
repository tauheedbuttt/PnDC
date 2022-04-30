
using System.Diagnostics;

class Temp
{
    public int[] arr;
    public int start;
    public int end;
    public Temp(int[] a, int b, int c)
    {
        arr = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            arr[i] = a[i];
        }
        start = b;
        end = c;
    }
}

class ThreadPoolSort : RankSort
{
    static int[] sorted;
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
    static void MyMethod(object obj)
    {
        var t = (Temp)obj;
        PlaceItem(t.arr, t.start, t.end);
    }
    public static string Execute(int[] arr)
    {
        Stopwatch timer = new Stopwatch();
        sorted = Enumerable.Repeat(-1, arr.Length).ToArray();
        timer.Start();

        int portions = arr.Length / 10;
        int start = 0;
        int end = 0;

        while (end < arr.Length)
        {
            end = start + portions;
            WaitCallback wc = new WaitCallback(MyMethod);
            Temp parameter = new Temp(arr, start, end);
            ThreadPool.QueueUserWorkItem(wc, parameter);
            start = end;
        }

        timer.Stop();
        return timer.Elapsed.TotalMilliseconds.ToString();
    }
}