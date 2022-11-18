using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    public class BenchmarkRawBitConversionVsFloatEquality
    {
        public static int Iterations = 100_000_000;

        public const float F1 = 3.14159f;
        public const float F2 = 2.198f;
        public const float F3 = 3.14159f;

        [Benchmark]
        public void SingleEqualsRawBits()
        {
            for (int i = 0; i < Iterations; i++)
            {
                int f1Bits = J2N.BitConversion.SingleToInt32Bits(F1);
                int f2Bits = J2N.BitConversion.SingleToInt32Bits(F2);
                int f3Bits = J2N.BitConversion.SingleToInt32Bits(F3);

                bool testUnequal1 = f1Bits == f2Bits;
                bool testUnequal2 = f2Bits == f1Bits;
                bool testEqual = f1Bits == f3Bits;
            }
        }

        [Benchmark]
        public void SingleEquals()
        {
            for (int i = 0; i < Iterations; i++)
            {
                bool testUnequal1 = F1 >= F2;
                bool testUnequal2 = F2 >= F1;
                bool testEqual = F1 >= F3;
            }
        }

        [Benchmark]
        public void SingleGreaterThanOrEqualsRawBits()
        {
            for (int i = 0; i < Iterations; i++)
            {
                int f1Bits = J2N.BitConversion.SingleToInt32Bits(F1);
                int f2Bits = J2N.BitConversion.SingleToInt32Bits(F2);
                int f3Bits = J2N.BitConversion.SingleToInt32Bits(F3);

                bool testUnequal1 = f1Bits == f2Bits;
                bool testUnequal2 = f2Bits == f1Bits;
                bool testEqual = f1Bits == f3Bits;
            }
        }

        [Benchmark]
        public void SingleGreaterThanOrEquals()
        {
            for (int i = 0; i < Iterations; i++)
            {
                bool testUnequal1 = F1 >= F2;
                bool testUnequal2 = F2 >= F1;
                bool testEqual = F1 >= F3;
            }
        }
    }
}
