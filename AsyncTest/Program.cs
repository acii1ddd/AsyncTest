using System.Diagnostics;

namespace AsyncTest;

class Program
{
    static async Task Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        SyncProcessing();
        stopwatch.Stop();
        Console.WriteLine($"Синхронная обработка заняла: {stopwatch.ElapsedMilliseconds} мс\n");
        
        stopwatch.Reset();
        stopwatch.Start();
        await AsyncProcessing();
        stopwatch.Stop();
        Console.WriteLine($"\nАсинхронная обработка заняла: {stopwatch.ElapsedMilliseconds} мс");
    }

    private static void SyncProcessing()
    {
        const int count = 3;
        
        for (var i = 0; i < count; i++)
        {
            var res = ProcessData($"Test {i + 1}");
            Console.WriteLine(res);
        }
    }

    private static string ProcessData(string dataName)
    {
        Thread.Sleep(3000);
        return $"Обработка {dataName} завершена за 3 секунды";
    }
    
    private static async Task AsyncProcessing()
    {
        var tasks = new List<Task<string>>();
     
        const int count = 3;
        for (var i = 0; i < count; i++)
        {
            var task = ProcessDataAsync($"Файл {i + 1}");
            tasks.Add(task);
        }

        while (tasks.Count > 0)
        {
            var res = await Task.WhenAny(tasks);
            tasks.Remove(res);
            Console.WriteLine(await res);
        }
    }
    
    private static async Task<string> ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000);
        return $"Обработка {dataName} завершена за 3 секунды";
    }
}