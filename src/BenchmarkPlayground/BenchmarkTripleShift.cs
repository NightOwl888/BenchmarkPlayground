//using BenchmarkDotNet.Attributes;
//using J2N.Numerics;

//namespace BenchmarkPlayground
//{
//    [MemoryDiagnoser]
//    public class BenchmarkTripleShift
//    {
//        public static int Iterations = 1000000000;

//        //[Benchmark]
//        //public void Int16TripleShift()
//        //{
//        //    for (short i = 0; i < Iterations; i++)
//        //    {
//        //        var _ = i.TripleShift(16);
//        //    }
//        //}

//        //[Benchmark]
//        //public void Int16DoubleCast()
//        //{
//        //    for (short i = 0; i < Iterations; i++)
//        //    {
//        //        var _ = (short)((ushort)i >> 16);
//        //    }
//        //}

//        [Benchmark]
//        public void Int32TripleShift()
//        {
//            for (int i = 0; i < Iterations; i++)
//            {
//                var _ = i.TripleShift(16);
//            }
//        }

//        [Benchmark]
//        public void In32DoubleCast()
//        {
//            for (int i = 0; i < Iterations; i++)
//            {
//                var _ = (int)((uint)i >> 16);
//            }
//        }

//        //[Benchmark]
//        //public void Int64TripleShift()
//        //{
//        //    for (long i = 0; i < Iterations; i++)
//        //    {
//        //        var _ = i.TripleShift(16);
//        //    }
//        //}

//        //[Benchmark]
//        //public void Int64DoubleCast()
//        //{
//        //    for (long i = 0; i < Iterations; i++)
//        //    {
//        //        var _ = (long)((ulong)i >> 16);
//        //    }
//        //}
//    }
//}
