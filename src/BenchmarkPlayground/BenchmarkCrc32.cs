using BenchmarkDotNet.Attributes;
using BenchmarkPlayground.Crc32;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    public class BenchmarkCrc32
    {
        private const int RandomSeed = 1234;
        private const int Iterations = 100000;

        //private static Random Random1 = new Random(RandomSeed);
        //private static Random Random2 = new Random(RandomSeed);
        //private static Random Random3 = new Random(RandomSeed);

        [Benchmark]
        public void UnbufferedCRC32_RunSequence()
        {
            var Random = new Random(RandomSeed);
            var data = new byte[Random.Next(1024)];
            Random.NextBytes(data);

            var c1 = new CRC32();

            for (int i = 0; i < Iterations; i++)
            {

                c1.Update(data);

                c1.Reset();

                Random.NextBytes(data);
                c1.Update(data);

                var _ = c1.Value;
            }
        }

        [Benchmark]
        public void BufferedCRC32_RunSequence()
        {
            var Random = new Random(RandomSeed);
            var data = new byte[Random.Next(1024)];
            Random.NextBytes(data);

            var c1 = new BufferedChecksum(new CRC32());

            for (int i = 0; i < Iterations; i++)
            {

                c1.Update(data);

                c1.Reset();

                Random.NextBytes(data);
                c1.Update(data);

                var _ = c1.Value;
            }
        }

        [Benchmark]
        public void BufferedCrc32Algorithm_RunSequence()
        {
            var Random = new Random(RandomSeed);
            var data = new byte[Random.Next(1024)];
            Random.NextBytes(data);

            var c2 = new BufferedCrc32Algorithm();

            for (int i = 0; i < Iterations; i++)
            {
                c2.TransformFinalBlock(data, 0, data.Length);

                c2.Initialize();

                Random.NextBytes(data);
                c2.Update(data);

                var _ = c2.Value;
            }
        }

        //[Benchmark]
        //public void BufferedCrc32Algorithm_PatchValue_RunSequence()
        //{
        //    var Random = new Random(RandomSeed);
        //    var data = new byte[Random.Next(1024)];
        //    Random.NextBytes(data);

        //    var c2 = new BufferedCrc32Algorithm2();

        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        c2.TransformFinalBlock(data, 0, data.Length);

        //        c2.Initialize();

        //        Random.NextBytes(data);
        //        c2.Update(data);

        //        var _ = c2.Value;
        //    }
        //}
    }
}
