using BenchmarkDotNet.Running;
using System;

namespace BenchmarkPlayground
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] foo = new int[5];

            //new BenchmarkSwitcher(typeof(Program).GetTypeInfo().Assembly).Run(args);
            BenchmarkRunner.Run<BenchmarkArrays>();
            //BenchmarkRunner.Run<BenchmarkStringCasing>();

#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
