using BenchmarkDotNet.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    public class BenchmarkBitArrayExtensions
    {
        private static readonly BitArray LoadedBits = LoadBitArray();
        private static readonly BitArray AllBits = new BitArray(128, true);
        private static BitArray LoadBitArray()
        {
            var bits = new BitArray(128, false);
            bits.Set(5, true);
            bits.Set(10, true);
            bits.Set(15, true);
            bits.Set(20, true);
            bits.Set(25, true);
            bits.Set(30, true);
            bits.Set(35, true);
            bits.Set(40, true);
            bits.Set(50, true);
            bits.Set(60, true);

            bits.Set(80, true);
            bits.Set(100, true);
            bits.Set(120, true);
            return bits;
        }


        //[Benchmark]
        //public int LoadedBits_Cardinality() => LoadedBits.Cardinality();

        //[Benchmark]
        //public int LoadedBits_Cardinality2() => LoadedBits.Cardinality2();

        //[Benchmark]
        //public int LoadedBits_Cardinality3() => LoadedBits.Cardinality3();


        //[Benchmark]
        //public int AllBits_Cardinality() => AllBits.Cardinality();

        //[Benchmark]
        //public int AllBits_Cardinality2() => AllBits.Cardinality2();

        //[Benchmark]
        //public int AllBits_Cardinality3() => AllBits.Cardinality3();
    }
}
