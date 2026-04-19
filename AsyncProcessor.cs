using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BenchmarkSolidApp
{
    public interface IAsyncProcessor
    {
        Task ExecuteAsync(List<int> data);
    }

    public class AsyncProcessor : IAsyncProcessor
    {
        public async Task ExecuteAsync(List<int> data)
        {
            Console.WriteLine("[Async] ...");

            await Task.Run(() =>
            {
                Parallel.ForEach(data, item =>
                {
                    DoHeavyWork(item);
                });
            });
        }

        private void DoHeavyWork(int number)
        {
            double result = 0;
            for (int i = 0; i < 100; i++) result += Math.Sqrt(number + i);
        }
    }
}