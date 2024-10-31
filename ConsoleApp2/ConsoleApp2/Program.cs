using System;
using System.Linq;
using System.Threading;

class Program
{
    static int[] numbers = new int[10000];
    static int maxNumber;
    static int minNumber;
    static double averageNumber;

    static void Main()
    {
        Random random = new Random();
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = random.Next(1, 10001);
        }

        Thread maxThread = new Thread(FindMax);
        Thread minThread = new Thread(FindMin);
        Thread avgThread = new Thread(FindAverage);

        maxThread.Start();
        minThread.Start();
        avgThread.Start();

        maxThread.Join();
        minThread.Join();
        avgThread.Join();

        Console.WriteLine($"Максимум: {maxNumber}");
        Console.WriteLine($"Минимум: {minNumber}");
        Console.WriteLine($"Среднее: {averageNumber:F2}");
    }

    static void FindMax()
    {
        maxNumber = numbers.Max();
    }

    static void FindMin()
    {
        minNumber = numbers.Min();
    }

    static void FindAverage()
    {
        averageNumber = numbers.Average();
    }
}
