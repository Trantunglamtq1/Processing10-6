using System;
using System.Collections.Generic;

namespace BenchmarkSolidApp
{
    public interface IProcessor
    {
        void ExecuteSync(List<int> data);
    }

    public class SyncProcessor : IProcessor
    {
        public void ExecuteSync(List<int> data)
        {
            Console.WriteLine("[Sync] Đang chạy bằng 1 nhân CPU...");

            foreach (var item in data)
            {
                DoHeavyWork(item);
            }
        }

        private void DoHeavyWork(int number)
        {
            double result = 0;
            for (int i = 0; i < 100; i++) result += Math.Sqrt(number + i);
        }
    }
}