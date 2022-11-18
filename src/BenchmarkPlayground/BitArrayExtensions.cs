using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    public static class BitArrayExtensions
    {

        /// <summary>
        /// Returns the number of bits set to true in this BitSet.
        /// </summary>
        /// <param name="bits">The BitArray object.</param>
        /// <returns>The number of bits set to true in this BitSet.</returns>
        public static int Cardinality2(this BitArray bits)
        {
            int count = 0;
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Returns the number of bits set to <c>true</c> in this <see cref="BitArray"/>.
        /// </summary>
        /// <param name="bits">This <see cref="BitArray"/>.</param>
        /// <returns>The number of bits set to true in this <see cref="BitArray"/>.</returns>
        public static int Cardinality(this BitArray bits)
        {
            if (bits == null)
                throw new ArgumentNullException(nameof(bits));
            int count = 0;

#if NETSTANDARD1_3
            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i])
                    count++;
            }
#else
            int bitsCount = bits.Count;
            int[] ints = new int[(bitsCount >> 5) + 1];
            int intsCount = ints.Length;

            bits.CopyTo(ints, 0);

            // fix for not truncated bits in last integer that may have been set to true with SetAll()
            ints[intsCount - 1] &= ~(-1 << (bitsCount % 32));

            for (int i = 0; i < intsCount; i++)
            {
                int c = ints[i];

                // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
                unchecked
                {
                    c -= (c >> 1) & 0x55555555;
                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
                }

                count += c;
            }
#endif
            return count;
        }

//        /// <summary>
//        /// Returns the number of bits set to <c>true</c> in this <see cref="BitArray"/>.
//        /// </summary>
//        /// <param name="bits">This <see cref="BitArray"/>.</param>
//        /// <returns>The number of bits set to true in this <see cref="BitArray"/>.</returns>
//        public static int Cardinality3(this BitArray bits)
//        {
//            if (bits == null)
//                throw new ArgumentNullException(nameof(bits));

//#if NETSTANDARD1_3
//            int count = 0;
//            for (int i = 0; i < bits.Length; i++)
//            {
//                if (bits[i])
//                    count++;
//            }
//            return count;
//#else
//            int bitsLength = bits.Length;
//            uint[] ints = new uint[(bitsLength >> 5) + 1];
//            int intsLength = ints.Length;
//            uint card = 0;

//            bits.CopyTo(ints, 0);

//            // fix for not truncated bits in last integer that may have been set to true with SetAll()
//            ints[intsLength - 1] &= (uint)~(-1 << (bitsLength % 32));

//            for (int i = ints.Length - 1; i >= 0; i--)
//            {
//                long a = ints[i];
//                // Take care of common cases.
//                if (a == 0)
//                    continue;
//                if (a == -1)
//                {
//                    card += 64;
//                    continue;
//                }

//                // Successively collapse alternating bit groups into a sum.
//                a = ((a >> 1) & 0x5555555555555555L) + (a & 0x5555555555555555L);
//                a = ((a >> 2) & 0x3333333333333333L) + (a & 0x3333333333333333L);
//                uint b = (uint)((a >> 32) + a);
//                b = ((b >> 4) & 0x0f0f0f0f) + (b & 0x0f0f0f0f);
//                b = ((b >> 8) & 0x00ff00ff) + (b & 0x00ff00ff);
//                card += ((b >> 16) & 0x0000ffff) + (b & 0x0000ffff);
//            }
//            return (int)card;

//            //for (int i = 0; i < intsLength; i++)
//            //{
//            //    card = ints[i];

//            //    // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
//            //    unchecked
//            //    {
//            //        card -= (card >> 1) & 0x55555555;
//            //        card = (card & 0x33333333) + ((card >> 2) & 0x33333333);
//            //        card = ((card + (card >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
//            //    }

//            //    count += card;
//            //}
//#endif
            
//        }


//        /// <summary>
//        /// Returns the number of bits set to <c>true</c> in this <see cref="BitArray"/>.
//        /// </summary>
//        /// <param name="bits">This <see cref="BitArray"/>.</param>
//        /// <returns>The number of bits set to true in this <see cref="BitArray"/>.</returns>
//        public static int Cardinality3(this BitArray bits)
//        {
//            if (bits == null)
//                throw new ArgumentNullException(nameof(bits));
//            int count = 0;

//#if NETSTANDARD1_3
//                    for (int i = 0; i < bits.Length; i++)
//                    {
//                        if (bits[i])
//                            count++;
//                    }
//#else
//            int bitsLength = bits.Length;
//            int[] ints = new int[(bitsLength >> 5) + 1];
//            int intsLength = ints.Length;
//            int c;

//            bits.CopyTo(ints, 0);

//            // fix for not truncated bits in last integer that may have been set to true with SetAll()
//            ints[intsLength - 1] &= ~(-1 << (bitsLength % 32));

//            for (int i = 0; i < intsLength; i++)
//            {
//                c = ints[i];

//                // magic (http://graphics.stanford.edu/~seander/bithacks.html#CountBitsSetParallel)
//                unchecked
//                {
//                    c -= (c >> 1) & 0x55555555;
//                    c = (c & 0x33333333) + ((c >> 2) & 0x33333333);
//                    c = ((c + (c >> 4) & 0xF0F0F0F) * 0x1010101) >> 24;
//                }

//                count += c;
//            }
//#endif
//            return count;
//        }

    }
}
