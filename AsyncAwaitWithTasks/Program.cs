using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncAwaitWithTasks
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Main started");
            Console.WriteLine("Main calling the async method");

            List<Task<int>> tasks = new List<Task<int>>();


            tasks.Add(Sleeper1Async(2000));
            tasks.Add(Sleeper2Async(3000));
            tasks.Add(Sleeper3Async(4000));

            Console.WriteLine("Main is doing soem work");
            Console.WriteLine("Main is doing soem work");
            Console.WriteLine("Main is doing soem work");
            Console.WriteLine("Main is doing soem work");

            while (tasks.Count > 0)
            {
                var completedTask = await Task.WhenAny(tasks);

                Console.WriteLine("slept for " + completedTask.Result + " ms");

                tasks.Remove(completedTask);
            }

            Console.Read();
        }

        private static async Task<int> Sleeper1Async(int v)
        {
            Console.WriteLine("Sleeper Methd started");
            await Task.Delay(v);
            return v;
        }

        private static async Task<int> Sleeper2Async(int v)
        {
            Console.WriteLine("Sleeper Methd started");
            await Task.Delay(v);
            return v;
        }

        private static async Task<int> Sleeper3Async(int v)
        {
            Console.WriteLine("Sleeper Methd started");
            await Task.Delay(v);
            return v;
        }
    }
}
