using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestDriver
{
	class Program
    {
        static async Task Main(string[] args) //async main: C# 7.1 feature
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 1000; i++)
            {
                HttpClient httpClient = new HttpClient();
                //async: 54597
                //sync: 54634
                var task = httpClient.GetAsync("http://localhost:54597/api/values").ContinueWith((t) =>
                {
                    Console.WriteLine("Request finished");
                });
                tasks.Add(task);
            }

            await Task.WhenAll(tasks);

            stopwatch.Stop();
            Console.WriteLine($"1000 requests done: {stopwatch.ElapsedMilliseconds}ms");
        }
    }
}
