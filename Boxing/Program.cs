using System;
using System.Diagnostics;
    class Program
{
    static void Main()
    {
        const int n = 100_000_000;
        int[] arr = new int[n];
        var rnd = new Random();
        for (int i = 0; i < n; i++)
        {
            arr[i] = rnd.Next(1, 100);
        }
        int[] CopyInt = new int[n];
        Stopwatch sw = new Stopwatch();

        sw.Start();
        Array.Copy(arr, CopyInt, n);
        sw.Stop();

        Console.WriteLine($"Array.Copy for int: {sw.ElapsedMilliseconds} ms");
        
        object[] objArr = new object[n];
        
        sw.Restart();
        Array.Copy(arr, objArr, n);
        sw.Stop();
        
        Console.WriteLine($"Array.Copy for object: {sw.ElapsedMilliseconds} ms");
    }
}
