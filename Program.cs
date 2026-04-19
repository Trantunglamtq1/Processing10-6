using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BenchmarkSolidApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int recordCount = 1_000_000;
            Console.WriteLine($"Đang tạo {recordCount:N0} records...\n");
            var data = Enumerable.Range(1, recordCount).ToList();

            Stopwatch sw = new Stopwatch();

            IProcessor syncWorker = new SyncProcessor();
            IAsyncProcessor asyncWorker = new AsyncProcessor();

            sw.Start();
            syncWorker.ExecuteSync(data);
            sw.Stop();
            Console.WriteLine($"-> Thời gian Sync: {sw.ElapsedMilliseconds} ms\n");

            sw.Restart();
            await asyncWorker.ExecuteAsync(data);
            sw.Stop();
            Console.WriteLine($"-> Thời gian Async: {sw.ElapsedMilliseconds} ms\n");

            Console.WriteLine("Hoàn tất Benchmark!");
        }
    }
}