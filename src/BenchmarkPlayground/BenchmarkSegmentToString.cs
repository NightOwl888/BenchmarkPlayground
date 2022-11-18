using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    public class BenchmarkSegmentToString
    {
        public class SegmentInfos
        {
            public static bool UseLegacySegmentNames
            {
                get => useLegacySegmentNames;
                set => useLegacySegmentNames = value;
            }
            internal static bool useLegacySegmentNames;
        }

        internal static string SegmentNumberToString(long segment)
        {
            switch (segment)
            {
                case 0: return "0";
                case 1: return "1";
                case 2: return "2";
                case 3: return "3";
                case 4: return "4";
                case 5: return "5";
                case 6: return "6";
                case 7: return "7";
                case 8: return "8";
                case 9: return "9";
            }

            if (!SegmentInfos.useLegacySegmentNames)
            {
                return segment switch
                {
                    10 => "a",
                    11 => "b",
                    12 => "c",
                    13 => "d",
                    14 => "e",
                    15 => "f",
                    16 => "g",
                    17 => "h",
                    18 => "i",
                    19 => "j",
                    20 => "k",
                    21 => "l",
                    22 => "m",
                    23 => "n",
                    24 => "o",
                    25 => "p",
                    26 => "q",
                    27 => "r",
                    28 => "s",
                    29 => "t",
                    30 => "u",
                    31 => "v",
                    32 => "w",
                    33 => "x",
                    34 => "y",
                    35 => "z",
                    36 => "10",
                    37 => "11",
                    38 => "12",
                    39 => "13",
                    40 => "14",
                    41 => "15",
                    42 => "16",
                    43 => "17",
                    44 => "18",
                    45 => "19",
                    46 => "1a",
                    47 => "1b",
                    48 => "1c",
                    49 => "1d",
                    50 => "1e",
                    51 => "1f",
                    52 => "1g",
                    53 => "1h",
                    54 => "1i",
                    55 => "1j",
                    56 => "1k",
                    57 => "1l",
                    58 => "1m",
                    59 => "1n",
                    60 => "1o",
                    61 => "1p",
                    62 => "1q",
                    63 => "1r",
                    64 => "1s",
                    65 => "1t",
                    66 => "1u",
                    67 => "1v",
                    68 => "1w",
                    69 => "1x",
                    70 => "1y",
                    71 => "1z",
                    72 => "20",
                    73 => "21",
                    74 => "22",
                    75 => "23",
                    76 => "24",
                    77 => "25",
                    78 => "26",
                    79 => "27",
                    80 => "28",
                    81 => "29",
                    82 => "2a",
                    83 => "2b",
                    84 => "2c",
                    85 => "2d",
                    86 => "2e",
                    87 => "2f",
                    88 => "2g",
                    89 => "2h",
                    90 => "2i",
                    91 => "2j",
                    92 => "2k",
                    93 => "2l",
                    94 => "2m",
                    95 => "2n",
                    96 => "2o",
                    97 => "2p",
                    98 => "2q",
                    99 => "2r",
                    _ => J2N.IntegralNumberExtensions.ToString(segment, J2N.Character.MaxRadix),
                };
            }

            return segment.ToString(CultureInfo.InvariantCulture);
        }

        internal static string SegmentNumberToString2(long segment)
        {
            if (SegmentInfos.useLegacySegmentNames)
                return segment.ToString(CultureInfo.InvariantCulture);

            return J2N.IntegralNumberExtensions.ToString(segment, J2N.Character.MaxRadix);
        }

        private const System.String digits = "0123456789abcdefghijklmnopqrstuvwxyz";

        public static System.String ToString(long number)
        {
            System.Text.StringBuilder s = new System.Text.StringBuilder();

            if (number == 0)
            {
                s.Append("0");
            }
            else
            {
                if (number < 0)
                {
                    s.Append("-");
                    number = -number;
                }

                while (number > 0)
                {
                    char c = digits[(int)number % 36];
                    s.Insert(0, c);
                    number = number / 36;
                }
            }

            return s.ToString();
        }



        public const int Iterations = 100000;


        [Benchmark]
        public void ToString_Lucene3()
        {
            SegmentInfos.UseLegacySegmentNames = false;
            for (int i = 0; i < Iterations; i++)
            {
                for (long seg = 100; seg < 200; seg++)
                    ToString(seg);
            }
        }

        [Benchmark]
        public void ToString_J2N()
        {
            SegmentInfos.UseLegacySegmentNames = false;
            for (int i = 0; i < Iterations; i++)
            {
                for (long seg = 100; seg < 200; seg++)
                    J2N.IntegralNumberExtensions.ToString(seg, J2N.Character.MaxRadix);
            }
        }


        //[Benchmark]
        //public void SegmentToString_SwitchCase()
        //{
        //    SegmentInfos.UseLegacySegmentNames = false;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (long seg = 0; seg < 100; seg++)
        //            SegmentNumberToString(seg);
        //    }
        //}

        //[Benchmark]
        //public void SegmentToString_MethodCall()
        //{
        //    SegmentInfos.UseLegacySegmentNames = false;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (long seg = 0; seg < 100; seg++)
        //            SegmentNumberToString2(seg);
        //    }
        //}

        //[Benchmark]
        //public void SegmentToString_SwitchCase_Legacy()
        //{
        //    SegmentInfos.UseLegacySegmentNames = true;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (long seg = 0; seg < 100; seg++)
        //            SegmentNumberToString(seg);
        //    }
        //}

        //[Benchmark]
        //public void SegmentToString_MethodCall_Legacy()
        //{
        //    SegmentInfos.UseLegacySegmentNames = true;
        //    for (int i = 0; i < Iterations; i++)
        //    {
        //        for (long seg = 0; seg < 100; seg++)
        //            SegmentNumberToString2(seg);
        //    }
        //}
    }
}
