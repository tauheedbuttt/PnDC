
class HelperFunctions
{
    public static void PrintArray(int[] arr)
    {
        foreach (var item in arr)
        {
            System.Console.Write($"{item}, ");
        }
        System.Console.WriteLine();
    }
    public static int[] RandomArray(int size)
    {
        Random random = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            arr[i] = random.Next(10);
        }
        return arr;
    }
}