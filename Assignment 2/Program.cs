// See https://aka.ms/new-console-template for more information
int[] sizes = { 100, 500, 1000, 5000, 10000, 20000, 50000, 100000 };
// int[] sizes = { 10 };
Console.WriteLine("N\t\tSerial Time\t\tMultithreaded Time\t\tThreadPool Time");
foreach (var size in sizes)
{
    int[] arr = HelperFunctions.RandomArray(size);
    string serialTime = SerialSort.Execute(arr);
    string multithreadTime = MultiThreadSort.Execute(arr);
    string threadPoolTime = ThreadPoolSort.Execute(arr);
    Console.WriteLine($"{size}\t\t{serialTime} ms\t\t{multithreadTime} ms\t\t\t{threadPoolTime} ms");
}
