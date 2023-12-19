#define FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
using BenchmarkDotNet.Attributes;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
#nullable enable


namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    [MediumRunJob]
    public class BenchmarkStringBuilderIndexing
    {
        private static readonly string s_chunkSplitSource1 = new string('a', 30) + new string('b', 40) + new string('c', 400) + new string('d', 4000) + "text" + new string('e', 3000);
        private static readonly string s_chunkSplitSource2 = new string('a', 300) + new string('b', 400) + new string('c', 400) + new string('d', 4000) + "text" + new string('e', 3000);
        private static readonly string s_chunkSplitSource3 = new string('x', 300) + new string('y', 200) + new string('z', 100);
        //private static readonly string s_noCapacityParamName = "valueCount";

        private static StringBuilder StringBuilderWithMultipleChunks() => new StringBuilder(20).Append(s_chunkSplitSource1).Append(s_chunkSplitSource2).Append(s_chunkSplitSource3);

        public const int Iterations = 100000;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private static StringBuilder StringBuilderLong;
        private static StringBuilder StringBuilderMedium;
        private static string StringLong;
        private static string StringMedium;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        [IterationSetup]
        public void IterationSetup()
        {
            StringBuilderLong = new StringBuilder(20).Append(s_chunkSplitSource1).Append(s_chunkSplitSource2).Append(s_chunkSplitSource3);
            StringLong = StringBuilderLong.ToString();
            StringBuilderMedium = new StringBuilder(20).Append(s_chunkSplitSource3).Append(s_chunkSplitSource3).Append("text").Append(s_chunkSplitSource3);
            StringMedium = StringBuilderMedium.ToString();
        }

        [Benchmark]
        public void String_IndexOf_Original_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringMedium.IndexOf("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_Original_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeString_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf3("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeCharArray_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf4("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeCharArrayWithArrayPool_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf5("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexer_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf2("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerInnerStruct_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf6("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerIntArrays_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf7("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerPackedLongs_Ordinal_Medium()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderMedium.IndexOf8("text", StringComparison.Ordinal);
            }
        }


        [Benchmark]
        public void String_IndexOf_Original_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringLong.IndexOf("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_Original_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeString_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf3("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeCharArray_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf4("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_MaterializeCharArrayWithArrayPool_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf5("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexer_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf2("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerInnerStruct_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf6("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerIntArrays_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf7("text", StringComparison.Ordinal);
            }
        }

        [Benchmark]
        public void IndexOf_WithIndexerPackedLongs_Ordinal_Long()
        {
            for (int i = 0; i < Iterations; i++)
            {
                StringBuilderLong.IndexOf8("text", StringComparison.Ordinal);
            }
        }

    }

    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Searches for the index of the specified character. The search for the
        /// character starts at the specified offset and moves towards the end.
        /// </summary>
        /// <param name="text">This <see cref="StringBuilder"/>.</param>
        /// <param name="value">The string to find.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>The index of the specified character, or <c>-1</c> if the character isn't found.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="text"/> or <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static int IndexOf(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf(text, value, 0, comparisonType);
        }

        /// <summary>
        /// Searches for the index of the specified character. The search for the
        /// character starts at the specified offset and moves towards the end.
        /// </summary>
        /// <param name="text">This <see cref="StringBuilder"/>.</param>
        /// <param name="value">The string to find.</param>
        /// <param name="startIndex">The starting offset.</param>
        /// <param name="comparisonType">One of the enumeration values that specifies the rules for the search.</param>
        /// <returns>The index of the specified character, or <c>-1</c> if the character isn't found.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="text"/> or <paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="startIndex"/> is less than 0 (zero) or greater than the length of this <see cref="StringBuilder"/>.</exception>
        /// <exception cref="ArgumentException"><paramref name="comparisonType"/> is not a <see cref="StringComparison"/> value.</exception>
        public static int IndexOf(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }


        public static int IndexOf2(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf2(text, value, 0, comparisonType);
        }

        public static int IndexOf2(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal2(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase2(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }

        public static int IndexOf3(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf3(text, value, 0, comparisonType);
        }

        public static int IndexOf3(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal3(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase3(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }

        public static int IndexOf4(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf4(text, value, 0, comparisonType);
        }

        public static int IndexOf4(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal4(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase4(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }


        public static int IndexOf5(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf5(text, value, 0, comparisonType);
        }

        public static int IndexOf5(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal5(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase5(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }

        public static int IndexOf6(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf6(text, value, 0, comparisonType);
        }

        public static int IndexOf6(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal6(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase6(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }

        public static int IndexOf7(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf7(text, value, 0, comparisonType);
        }

        public static int IndexOf7(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal7(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase7(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }

        public static int IndexOf8(this StringBuilder text, string value, StringComparison comparisonType)
        {
            return IndexOf8(text, value, 0, comparisonType);
        }

        public static int IndexOf8(this StringBuilder text, string value, int startIndex, StringComparison comparisonType)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));
            if (value is null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0 || startIndex > text.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            if (value.Length == 0)
                return 0;

            return comparisonType switch
            {
                StringComparison.Ordinal => IndexOfOrdinal8(text, value, startIndex),
                StringComparison.OrdinalIgnoreCase => IndexOfOrdinalIgnoreCase8(text, value, startIndex),
                _ => text.ToString().IndexOf(value, startIndex, comparisonType),
            };
        }


#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0];
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (text[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (text[i + index] == value[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (text[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = text[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }




#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal2(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            var forwardIndexer = new StringBuilderIndexer(text, iterateForward: true);

            char firstChar = forwardIndexer[0];
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (forwardIndexer[i + index] == forwardIndexer[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase2(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            var forwardIndexer = new StringBuilderIndexer(text, iterateForward: true);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = forwardIndexer[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }



#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal3(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0];
            int index;
            string materialized = text.ToString();
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (materialized[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (materialized[i + index] == value[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase3(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            string materialized = text.ToString();
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (materialized[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = materialized[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }


#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal4(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0];
            int index;
            char[] materialized = new char[text.Length];
            text.CopyTo(0, materialized, 0, textLength);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (materialized[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (materialized[i + index] == value[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase4(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            char[] materialized = new char[text.Length];
            text.CopyTo(0, materialized, 0, textLength);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (materialized[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = materialized[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }


#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal5(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0];
            int index;
            char[] materialized = ArrayPool<char>.Shared.Rent(textLength);
            try
            {
                text.CopyTo(0, materialized, 0, textLength);
                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (materialized[i] == firstChar)
                    {
                        index = 1;
                        while ((index < length) && (materialized[i + index] == value[index]))
                            ++index;

                        if (index == length)
                            return i;
                    }
                }
            }
            finally
            {
                ArrayPool<char>.Shared.Return(materialized);
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase5(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            char[] materialized = ArrayPool<char>.Shared.Rent(textLength);
            try
            {
                text.CopyTo(0, materialized, 0, textLength);
                for (int i = startIndex; i < maxSearchLength; ++i)
                {
                    if (materialized[i] == firstChar)
                    {
                        index = 1;
                        while ((index < length) &&
                            ((c1 = materialized[i + index]) == (c2 = value[index]) ||
                            textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                            // Required for unicode that we test both cases
                            textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                        {
                            ++index;
                        }

                        if (index == length)
                            return i;
                    }
                }
            }
            finally
            {
                ArrayPool<char>.Shared.Return(materialized);
            }
            return -1;
        }


#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal6(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            var forwardIndexer = new StringBuilderIndexer2(text, iterateForward: true);

            char firstChar = forwardIndexer[0];
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (forwardIndexer[i + index] == forwardIndexer[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase6(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            var forwardIndexer = new StringBuilderIndexer2(text, iterateForward: true);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = forwardIndexer[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }


#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal7(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            var forwardIndexer = new StringBuilderIndexer3(text, iterateForward: true);

            char firstChar = forwardIndexer[0];
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (forwardIndexer[i + index] == forwardIndexer[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase7(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            var forwardIndexer = new StringBuilderIndexer3(text, iterateForward: true);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = forwardIndexer[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinal8(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            var forwardIndexer = new StringBuilderIndexer4(text, iterateForward: true);

            char firstChar = forwardIndexer[0];
            int index;
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) && (forwardIndexer[i + index] == forwardIndexer[index]))
                        ++index;

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }

#if FEATURE_METHODIMPLOPTIONS_AGRESSIVEINLINING
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
#endif 
        private static int IndexOfOrdinalIgnoreCase8(StringBuilder text, string value, int startIndex)
        {
            int length = value.Length;
            if (length == 0)
                return 0;
            int textLength = text.Length;
            int maxSearchLength = (textLength - length) + 1;
            char firstChar = value[0], c1, c2;
            var textInfo = CultureInfo.InvariantCulture.TextInfo;
            int index;
            var forwardIndexer = new StringBuilderIndexer4(text, iterateForward: true);
            for (int i = startIndex; i < maxSearchLength; ++i)
            {
                if (forwardIndexer[i] == firstChar)
                {
                    index = 1;
                    while ((index < length) &&
                        ((c1 = forwardIndexer[i + index]) == (c2 = value[index]) ||
                        textInfo.ToUpper(c1) == textInfo.ToUpper(c2) ||
                        // Required for unicode that we test both cases
                        textInfo.ToLower(c1) == textInfo.ToLower(c2)))
                    {
                        ++index;
                    }

                    if (index == length)
                        return i;
                }
            }
            return -1;
        }
    }


    internal ref struct StringBuilderIndexer
    {
        private readonly StringBuilder stringBuilder;
        private readonly List<MemoryBounds>? chunks;
        private ReadOnlyMemory<char> currentChunk;
        private int currentChunkIndex;
        private int currentLowerBound;
        private int currentUpperBound;
        private bool iterateForward;

        public StringBuilderIndexer(StringBuilder stringBuilder, bool iterateForward = true)
        {
            this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
            this.iterateForward = iterateForward;
            chunks = null;
            bool first = true;
            int lowerBound = 0;
            int upperBound = -1;
            currentChunkIndex = 0;
            currentLowerBound = lowerBound;
            currentUpperBound = upperBound;
            currentChunk = null;

            foreach (var chunk in stringBuilder.GetChunks())
            {
                lowerBound += upperBound + 1;
                upperBound += chunk.Length;
                if (first)
                {
                    currentChunkIndex = 0;
                    currentLowerBound = lowerBound;
                    currentUpperBound = upperBound;
                    currentChunk = chunk;
                    first = false;
                }
                else
                {
                    if (chunks is null)
                    {
                        chunks = new List<MemoryBounds>();
                        chunks.Add(new MemoryBounds(this.currentChunk, currentLowerBound, currentUpperBound));
                    }
                    chunks.Add(new MemoryBounds(chunk, lowerBound, upperBound));
                }
            }
            Reset();
        }

        private void SetCurrentChunkFromIndex(int index)
        {
            bool found = false;
            if (iterateForward)
            {
                while (index > currentUpperBound)
                {
                    found = true;
                    if (chunks != null)
                    {
                        currentChunkIndex++;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
                if (found) return;
                while (index < currentLowerBound)
                {
                    if (chunks != null)
                    {
                        currentChunkIndex--;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
            }
            else
            {
                while (index < currentLowerBound)
                {
                    found = true;
                    if (chunks != null)
                    {
                        currentChunkIndex--;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
                if (found) return;
                while (index > currentUpperBound)
                {
                    if (chunks != null)
                    {
                        currentChunkIndex++;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
            }
        }

        private void SetChunk(MemoryBounds chunk)
        {
            currentChunk = chunk.Chunk;
            currentLowerBound = chunk.LowerBound;
            currentUpperBound = chunk.UpperBound;
        }

        public void Reset()
        {
            if (chunks != null)
            {
                var chunk = iterateForward ? chunks[0] : chunks[^1];
                SetChunk(chunk);
                currentChunkIndex = iterateForward ? 0 : chunks.Count - 1;
            }
        }

        public void Reset(bool iterateForward)
        {
            this.iterateForward = iterateForward;
            Reset();
        }

        public bool IterateForward => iterateForward;

        public char this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                return currentChunk.Span[index - currentLowerBound];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                unsafe
                {
                    using var handle = currentChunk.Pin();
                    char* pointer = (char*)handle.Pointer;
                    pointer[index - currentLowerBound] = value;
                }
            }
        }

        private class MemoryBounds
        {
            public MemoryBounds(ReadOnlyMemory<char> chunk, int lowerBound, int upperBound)
            {
                Chunk = chunk;
                LowerBound = lowerBound;
                UpperBound = upperBound;
            }

            public readonly ReadOnlyMemory<char> Chunk;
            public readonly int LowerBound; // Index of lower bound of the chunk relative to the beginning of the StringBuilder
            public readonly int UpperBound; // Index of uppser bound of the chunk relative to the beginning of the StringBuilder
        }

        private static class SR
        {
            public const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the string/array/collection.";
        }
    }

    internal ref struct StringBuilderIndexer4
    {
        private /*readonly*/ StringBuilder stringBuilder;
        private /*readonly*/ ChunkBoundsPacker boundsPacker;
        private /*readonly*/ bool usePacker;
        private /*readonly*/ int[]? lowerBounds;
        private /*readonly*/ int[]? upperBounds;
        private ReadOnlyMemory<char> currentChunk;
        private int chunkCount;
        private int currentChunkIndex;
        private int currentLowerBound;
        private int currentUpperBound;
        private bool iterateForward;


        public StringBuilderIndexer4(StringBuilder stringBuilder, bool iterateForward = true)
        {
            this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
            this.iterateForward = iterateForward;

            boundsPacker = default;
            lowerBounds = null;
            upperBounds = null;
            bool first = true;
            bool bound0Set = false;
            int lowerBound = 0;
            int upperBound = -1;
            chunkCount = 0;
            currentChunkIndex = 0;
            currentLowerBound = lowerBound;
            currentUpperBound = upperBound;
            currentChunk = null;

            foreach (var chunk in stringBuilder.GetChunks())
                chunkCount++;

            usePacker = chunkCount <= ChunkBoundsPacker.TotalChunks && stringBuilder.Length < ChunkBoundsPacker.MaxUpperBound;

            int chunkIndex = 0;
            int prevChunkLength = 0;
            foreach (var chunk in stringBuilder.GetChunks())
            {
                lowerBound += prevChunkLength;
                upperBound += chunk.Length;
                prevChunkLength = chunk.Length;
                if (first)
                {
                    currentChunkIndex = 0;
                    currentLowerBound = lowerBound;
                    currentUpperBound = upperBound;
                    currentChunk = chunk;
                    first = false;
                }
                else
                {
                    if (!bound0Set)
                    {
                        SetBounds(0, currentLowerBound, currentUpperBound);
                        bound0Set = true;
                    }
                    SetBounds(chunkIndex, lowerBound, upperBound);
                }
                chunkIndex++;
            }
            Reset();
        }

        private void SetBounds(int chunkIndex, int lowerBound, int upperBound)
        {
            if (usePacker)
            {
                boundsPacker.SetBounds(chunkIndex, lowerBound, upperBound);
            }
            else
            {
                lowerBounds ??= new int[chunkCount];
                upperBounds ??= new int[chunkCount];
                lowerBounds![chunkIndex] = lowerBound;
                upperBounds![chunkIndex] = upperBound;
            }
        }

        private void GetBounds(int chunkIndex, out int lowerBound, out int upperBound)
        {
            if (usePacker)
            {
                boundsPacker.GetBounds(chunkIndex, out lowerBound, out upperBound);
            }
            else
            {
                if (chunkIndex == 0 && (lowerBounds is null || upperBounds is null))
                    throw new InvalidOperationException(string.Format(SR.InvalidOperation_CannotIndexNullObject, "int[]"));

                lowerBound = lowerBounds![chunkIndex];
                upperBound = upperBounds![chunkIndex];
            }
        }

        private bool IsWithinBounds(int chunkIndex, int index)
        {
            GetBounds(chunkIndex, out int lowerBound, out int upperBound);
            return index >= lowerBound && index <= upperBound;
        }

        private void SetCurrentChunkFromIndex(int index) // Must not call this unless lowerBounds and UpperBounds are allocated
        {
            if (iterateForward)
            {
                // Scan forward first
                for (int i = currentChunkIndex + 1; i < chunkCount; i++)
                {
                    if (IsWithinBounds(i, index))
                    {
                        SetChunk(i);
                        return;
                    }
                }
                for (int i = currentChunkIndex - 1; i >= 0; i--)
                {
                    if (IsWithinBounds(i, index))
                    {
                        SetChunk(i);
                        return;
                    }
                }
            }
            else
            {
                // Scan backward first
                for (int i = currentChunkIndex - 1; i >= 0; i--)
                {
                    if (IsWithinBounds(i, index))
                    {
                        SetChunk(i);
                        return;
                    }
                }
                for (int i = currentChunkIndex + 1; i < chunkCount; i++)
                {
                    if (IsWithinBounds(i, index))
                    {
                        SetChunk(i);
                        return;
                    }
                }
            }
        }

        private void SetChunk(int chunkIndex) // Must not call this unless lowerBounds and UpperBounds are allocated
        {
            if (currentChunkIndex == chunkIndex)
                return;

            int index = -1;
            foreach (var chunk in stringBuilder.GetChunks())
            {
                index++;
                if (index == chunkIndex)
                {
                    currentChunk = chunk;
                    GetBounds(chunkIndex, out int lowerBound, out int upperBound);
                    currentLowerBound = lowerBound;
                    currentUpperBound = upperBound;
                    currentChunkIndex = chunkIndex;
                    return;
                }
            }
        }

        public void Reset()
        {
            int chunkIndex = iterateForward ? 0 : chunkCount - 1;
            SetChunk(chunkIndex);
        }

        public void Reset(bool iterateForward)
        {
            this.iterateForward = iterateForward;
            Reset();
        }

        public bool IterateForward => iterateForward;

        public char this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                return currentChunk.Span[index - currentLowerBound];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                unsafe
                {
                    using var handle = currentChunk.Pin();
                    char* pointer = (char*)handle.Pointer;
                    pointer[index - currentLowerBound] = value;
                }
            }
        }

        private ref struct ChunkBoundsPacker
        {
            public const int BitsPerChunk = 16; // Number of bits allocated for each chunk
            public const int ChunksPerULong = 64 / BitsPerChunk; // Number of chunks per ulong variable
            public const int TotalChunks = 16;
            public const int MaxUpperBound = (1 << BitsPerChunk) - 1; // Maximum value that can be stored with BitsPerChunk bits

            private ulong lowerBound1;
            private ulong upperBound1;
            private ulong lowerBound2;
            private ulong upperBound2;
            private ulong lowerBound3;
            private ulong upperBound3;
            private ulong lowerBound4;
            private ulong upperBound4;

            public void SetBounds(int chunkIndex, int lowerBound, int upperBound)
            {
                if (chunkIndex < 0 || chunkIndex >= TotalChunks)
                {
                    throw new ArgumentOutOfRangeException(nameof(chunkIndex));
                }

                if (lowerBound < 0 || lowerBound > MaxUpperBound || upperBound < 0 || upperBound > MaxUpperBound)
                {
                    throw new ArgumentOutOfRangeException("Bounds must be between 0 and MaxUpperBound");
                }

                // Calculate the bit offset for the chunk within the ulong variables
                int bitOffset = (chunkIndex % ChunksPerULong) * BitsPerChunk;

                // Clear the existing bits for the chunk
                switch (chunkIndex / ChunksPerULong)
                {
                    case 0:
                        lowerBound1 &= ~((ulong)MaxUpperBound << bitOffset);
                        upperBound1 &= ~((ulong)MaxUpperBound << bitOffset);
                        break;
                    case 1:
                        lowerBound2 &= ~((ulong)MaxUpperBound << bitOffset);
                        upperBound2 &= ~((ulong)MaxUpperBound << bitOffset);
                        break;
                    case 2:
                        lowerBound3 &= ~((ulong)MaxUpperBound << bitOffset);
                        upperBound3 &= ~((ulong)MaxUpperBound << bitOffset);
                        break;
                    case 3:
                        lowerBound4 &= ~((ulong)MaxUpperBound << bitOffset);
                        upperBound4 &= ~((ulong)MaxUpperBound << bitOffset);
                        break;
                }

                // Pack the new bounds into the ulong
                switch (chunkIndex / ChunksPerULong)
                {
                    case 0:
                        lowerBound1 |= ((ulong)lowerBound & (ulong)MaxUpperBound) << bitOffset;
                        upperBound1 |= ((ulong)upperBound & (ulong)MaxUpperBound) << bitOffset;
                        break;
                    case 1:
                        lowerBound2 |= ((ulong)lowerBound & (ulong)MaxUpperBound) << bitOffset;
                        upperBound2 |= ((ulong)upperBound & (ulong)MaxUpperBound) << bitOffset;
                        break;
                    case 2:
                        lowerBound3 |= ((ulong)lowerBound & (ulong)MaxUpperBound) << bitOffset;
                        upperBound3 |= ((ulong)upperBound & (ulong)MaxUpperBound) << bitOffset;
                        break;
                    case 3:
                        lowerBound4 |= ((ulong)lowerBound & (ulong)MaxUpperBound) << bitOffset;
                        upperBound4 |= ((ulong)upperBound & (ulong)MaxUpperBound) << bitOffset;
                        break;
                }
            }

            public void GetBounds(int chunkIndex, out int lowerBound, out int upperBound)
            {
                if (chunkIndex < 0 || chunkIndex >= TotalChunks)
                {
                    throw new ArgumentOutOfRangeException(nameof(chunkIndex));
                }

                // Calculate the bit offset for the chunk within the ulong variables
                int bitOffset = (chunkIndex % ChunksPerULong) * BitsPerChunk;

                // Extract the packed bounds for the given chunk
                switch (chunkIndex / ChunksPerULong)
                {
                    case 0:
                        lowerBound = (int)((lowerBound1 >> bitOffset) & (ulong)MaxUpperBound);
                        upperBound = (int)((upperBound1 >> bitOffset) & (ulong)MaxUpperBound);
                        break;
                    case 1:
                        lowerBound = (int)((lowerBound2 >> bitOffset) & (ulong)MaxUpperBound);
                        upperBound = (int)((upperBound2 >> bitOffset) & (ulong)MaxUpperBound);
                        break;
                    case 2:
                        lowerBound = (int)((lowerBound3 >> bitOffset) & (ulong)MaxUpperBound);
                        upperBound = (int)((upperBound3 >> bitOffset) & (ulong)MaxUpperBound);
                        break;
                    case 3:
                        lowerBound = (int)((lowerBound4 >> bitOffset) & (ulong)MaxUpperBound);
                        upperBound = (int)((upperBound4 >> bitOffset) & (ulong)MaxUpperBound);
                        break;
                    default:
                        lowerBound = upperBound = 0; // This should not happen
                        break;
                }
            }

            public void PrintPackedBounds()
            {
                Console.WriteLine($"Lower Bounds 1: {Convert.ToString((long)lowerBound1, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Upper Bounds 1: {Convert.ToString((long)upperBound1, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Lower Bounds 2: {Convert.ToString((long)lowerBound2, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Upper Bounds 2: {Convert.ToString((long)upperBound2, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Lower Bounds 3: {Convert.ToString((long)lowerBound3, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Upper Bounds 3: {Convert.ToString((long)upperBound3, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Lower Bounds 4: {Convert.ToString((long)lowerBound4, 2).PadLeft(64, '0')}");
                Console.WriteLine($"Upper Bounds 4: {Convert.ToString((long)upperBound4, 2).PadLeft(64, '0')}");
            }
        }

        private static class SR
        {
            public const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the string/array/collection.";
            public const string InvalidOperation_CannotIndexNullObject = "Cannot index a null {0}.";
        }
    }

    //internal ref struct StringBuilderIndexer4
    //{
    //    private /*readonly*/ StringBuilder stringBuilder;
    //    private /*readonly*/ ChunkBoundsPacker boundsPacker;
    //    private /*readonly*/ bool usePacker;
    //    private /*readonly*/ int[]? lowerBounds;
    //    private /*readonly*/ int[]? upperBounds;
    //    private ReadOnlyMemory<char> currentChunk;
    //    private int chunkCount;
    //    private int currentChunkIndex;
    //    private int currentLowerBound;
    //    private int currentUpperBound;
    //    private bool iterateForward;


    //    public StringBuilderIndexer4(StringBuilder stringBuilder, bool iterateForward = true)
    //    {
    //        this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
    //        this.iterateForward = iterateForward;

    //        boundsPacker = default;
    //        lowerBounds = null;
    //        upperBounds = null;
    //        bool first = true;
    //        bool bound0Set = false;
    //        int lowerBound = 0;
    //        int upperBound = -1;
    //        chunkCount = 0;
    //        currentChunkIndex = 0;
    //        currentLowerBound = lowerBound;
    //        currentUpperBound = upperBound;
    //        currentChunk = null;

    //        foreach (var chunk in stringBuilder.GetChunks())
    //            chunkCount++;

    //        usePacker = chunkCount <= 10 && stringBuilder.Length < 2048;

    //        int chunkIndex = 0;
    //        int prevChunkLength = 0;
    //        foreach (var chunk in stringBuilder.GetChunks())
    //        {
    //            lowerBound += prevChunkLength;
    //            upperBound += chunk.Length;
    //            prevChunkLength = chunk.Length;
    //            if (first)
    //            {
    //                currentChunkIndex = 0;
    //                currentLowerBound = lowerBound;
    //                currentUpperBound = upperBound;
    //                currentChunk = chunk;
    //                first = false;
    //            }
    //            else
    //            {
    //                if (!bound0Set)
    //                {
    //                    SetBounds(0, currentLowerBound, currentUpperBound);
    //                    bound0Set = true;
    //                }
    //                SetBounds(chunkIndex, lowerBound, upperBound);
    //            }
    //            chunkIndex++;
    //        }
    //        Reset();
    //    }

    //    private void SetBounds(int chunkIndex, int lowerBound, int upperBound)
    //    {
    //        if (usePacker)
    //        {
    //            boundsPacker.SetBounds(chunkIndex, lowerBound, upperBound);
    //        }
    //        else
    //        {
    //            lowerBounds ??= new int[chunkCount];
    //            upperBounds ??= new int[chunkCount];
    //            lowerBounds![chunkIndex] = lowerBound;
    //            upperBounds![chunkIndex] = upperBound;
    //        }
    //    }

    //    private void GetBounds(int chunkIndex, out int lowerBound, out int upperBound)
    //    {
    //        if (usePacker)
    //        {
    //            boundsPacker.GetBounds(chunkIndex, out lowerBound, out upperBound);
    //        }
    //        else
    //        {
    //            if (chunkIndex == 0 && (lowerBounds is null || upperBounds is null))
    //                throw new InvalidOperationException(string.Format(SR.InvalidOperation_CannotIndexNullObject, "int[]"));

    //            lowerBound = lowerBounds![chunkIndex];
    //            upperBound = upperBounds![chunkIndex];
    //        }
    //    }

    //    private bool IsWithinBounds(int chunkIndex, int index)
    //    {
    //        GetBounds(chunkIndex, out int lowerBound, out int upperBound);
    //        return index >= lowerBound && index <= upperBound;
    //    }

    //    private void SetCurrentChunkFromIndex(int index) // Must not call this unless lowerBounds and UpperBounds are allocated
    //    {
    //        if (iterateForward)
    //        {
    //            // Scan forward first
    //            for (int i = currentChunkIndex + 1; i < chunkCount; i++)
    //            {
    //                if (IsWithinBounds(i, index))
    //                {
    //                    SetChunk(i);
    //                    return;
    //                }
    //            }
    //            for (int i = currentChunkIndex - 1; i >= 0; i--)
    //            {
    //                if (IsWithinBounds(i, index))
    //                {
    //                    SetChunk(i);
    //                    return;
    //                }
    //            }
    //        }
    //        else
    //        {
    //            // Scan backward first
    //            for (int i = currentChunkIndex - 1; i >= 0; i--)
    //            {
    //                if (IsWithinBounds(i, index))
    //                {
    //                    SetChunk(i);
    //                    return;
    //                }
    //            }
    //            for (int i = currentChunkIndex + 1; i < chunkCount; i++)
    //            {
    //                if (IsWithinBounds(i, index))
    //                {
    //                    SetChunk(i);
    //                    return;
    //                }
    //            }
    //        }
    //    }

    //    private void SetChunk(int chunkIndex) // Must not call this unless lowerBounds and UpperBounds are allocated
    //    {
    //        if (currentChunkIndex == chunkIndex)
    //            return;

    //        int index = -1;
    //        foreach (var chunk in stringBuilder.GetChunks())
    //        {
    //            index++;
    //            if (index == chunkIndex)
    //            {
    //                currentChunk = chunk;
    //                GetBounds(chunkIndex, out int lowerBound, out int upperBound);
    //                currentLowerBound = lowerBound;
    //                currentUpperBound = upperBound;
    //                currentChunkIndex = chunkIndex;
    //                return;
    //            }
    //        }
    //    }

    //    public void Reset()
    //    {
    //        int chunkIndex = iterateForward ? 0 : chunkCount - 1;
    //        SetChunk(chunkIndex);
    //    }

    //    public void Reset(bool iterateForward)
    //    {
    //        this.iterateForward = iterateForward;
    //        Reset();
    //    }

    //    public bool IterateForward => iterateForward;

    //    public char this[int index]
    //    {
    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        get
    //        {
    //            if ((uint)index >= (uint)stringBuilder.Length)
    //            {
    //                throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
    //            }

    //            if (index < currentLowerBound || index > currentUpperBound)
    //            {
    //                SetCurrentChunkFromIndex(index);
    //            }

    //            return currentChunk.Span[index - currentLowerBound];
    //        }

    //        [MethodImpl(MethodImplOptions.AggressiveInlining)]
    //        set
    //        {
    //            if ((uint)index >= (uint)stringBuilder.Length)
    //            {
    //                throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
    //            }

    //            if (index < currentLowerBound || index > currentUpperBound)
    //            {
    //                SetCurrentChunkFromIndex(index);
    //            }

    //            unsafe
    //            {
    //                using var handle = currentChunk.Pin();
    //                char* pointer = (char*)handle.Pointer;
    //                pointer[index - currentLowerBound] = value;
    //            }
    //        }
    //    }

    //    private ref struct ChunkBoundsPacker
    //    {
    //        private const int BitsPerChunk = 11; // Number of bits allocated for each chunk
    //        private const int ChunksPerULong = 64 / BitsPerChunk; // Number of chunks per ulong variable

    //        private ulong lowerBound1;
    //        private ulong upperBound1;
    //        private ulong lowerBound2;
    //        private ulong upperBound2;

    //        public void SetBounds(int chunkIndex, int lowerBound, int upperBound)
    //        {
    //            if (chunkIndex < 0 || chunkIndex >= ChunksPerULong * 2)
    //            {
    //                throw new ArgumentOutOfRangeException(nameof(chunkIndex));
    //            }

    //            // Calculate the bit offset for the chunk within the ulong variables
    //            int bitOffset = (chunkIndex % ChunksPerULong) * BitsPerChunk;

    //            // Clear the existing bits for the chunk
    //            if (chunkIndex < ChunksPerULong)
    //            {
    //                lowerBound1 &= ~((0x7FFUL) << bitOffset);
    //                upperBound1 &= ~((0x7FFUL) << bitOffset);

    //                // Pack the new bounds into the ulong
    //                lowerBound1 |= ((ulong)lowerBound & 0x7FFUL) << bitOffset;
    //                upperBound1 |= ((ulong)upperBound & 0x7FFUL) << bitOffset;
    //            }
    //            else
    //            {
    //                bitOffset += ChunksPerULong * BitsPerChunk; // Offset for the second set of ulongs
    //                int remainingChunks = chunkIndex - ChunksPerULong;

    //                lowerBound2 &= ~((0x7FFUL) << (bitOffset - ChunksPerULong * BitsPerChunk));
    //                upperBound2 &= ~((0x7FFUL) << (bitOffset - ChunksPerULong * BitsPerChunk));

    //                // Pack the new bounds into the ulong
    //                lowerBound2 |= ((ulong)lowerBound & 0x7FFUL) << (bitOffset - ChunksPerULong * BitsPerChunk);
    //                upperBound2 |= ((ulong)upperBound & 0x7FFUL) << (bitOffset - ChunksPerULong * BitsPerChunk);
    //            }
    //        }

    //        public void GetBounds(int chunkIndex, out int lowerBound, out int upperBound)
    //        {
    //            if (chunkIndex < 0 || chunkIndex >= ChunksPerULong * 2)
    //            {
    //                throw new ArgumentOutOfRangeException(nameof(chunkIndex));
    //            }

    //            // Calculate the bit offset for the chunk within the ulong variables
    //            int bitOffset = (chunkIndex % ChunksPerULong) * BitsPerChunk;

    //            // Extract the packed bounds for the given chunk
    //            if (chunkIndex < ChunksPerULong)
    //            {
    //                lowerBound = (int)((lowerBound1 >> bitOffset) & 0x7FFUL);
    //                upperBound = (int)((upperBound1 >> bitOffset) & 0x7FFUL);
    //            }
    //            else
    //            {
    //                bitOffset += ChunksPerULong * BitsPerChunk; // Correct offset for the second set of ulongs
    //                int remainingChunks = chunkIndex - ChunksPerULong;

    //                lowerBound = (int)((lowerBound2 >> (bitOffset - ChunksPerULong * BitsPerChunk)) & 0x7FFUL);
    //                upperBound = (int)((upperBound2 >> (bitOffset - ChunksPerULong * BitsPerChunk)) & 0x7FFUL);
    //            }
    //        }

    //        public void PrintPackedBounds()
    //        {
    //            Console.WriteLine($"Lower Bounds 1: {Convert.ToString((long)lowerBound1, 2).PadLeft(64, '0')}");
    //            Console.WriteLine($"Upper Bounds 1: {Convert.ToString((long)upperBound1, 2).PadLeft(64, '0')}");
    //            Console.WriteLine($"Lower Bounds 2: {Convert.ToString((long)lowerBound2, 2).PadLeft(64, '0')}");
    //            Console.WriteLine($"Upper Bounds 2: {Convert.ToString((long)upperBound2, 2).PadLeft(64, '0')}");
    //        }
    //    }

    //    private static class SR
    //    {
    //        public const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the string/array/collection.";
    //        public const string InvalidOperation_CannotIndexNullObject = "Cannot index a null {0}.";
    //    }
    //}

    internal ref struct StringBuilderIndexer3
    {
        private readonly StringBuilder stringBuilder;
        private readonly int[]? lowerBounds;
        private readonly int[]? upperBounds;
        private ReadOnlyMemory<char> currentChunk;
        private int currentChunkIndex;
        private int currentLowerBound;
        private int currentUpperBound;
        private bool iterateForward;

        public StringBuilderIndexer3(StringBuilder stringBuilder, bool iterateForward = true)
        {
            this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
            this.iterateForward = iterateForward;

            lowerBounds = null;
            upperBounds = null;
            bool first = true;
            int lowerBound = 0;
            int upperBound = -1;
            int chunkCount = 0;
            currentChunkIndex = 0;
            currentLowerBound = lowerBound;
            currentUpperBound = upperBound;
            currentChunk = null;

            foreach (var chunk in stringBuilder.GetChunks())
                chunkCount++;

            int chunkIndex = 0;
            int prevChunkLength = 0;
            foreach (var chunk in stringBuilder.GetChunks())
            {
                lowerBound += prevChunkLength;
                upperBound += chunk.Length;
                prevChunkLength = chunk.Length;
                if (first)
                {
                    currentChunkIndex = 0;
                    currentLowerBound = lowerBound;
                    currentUpperBound = upperBound;
                    currentChunk = chunk;
                    first = false;
                }
                else
                {
                    if (lowerBounds is null)
                    {
                        lowerBounds = new int[chunkCount];
                        upperBounds = new int[chunkCount];
                        lowerBounds[0] = currentLowerBound;
                        upperBounds[0] = currentUpperBound;
                    }
                    lowerBounds[chunkIndex] = lowerBound;
                    upperBounds![chunkIndex] = upperBound;
                }
                chunkIndex++;
            }
            Reset();
        }

        private void SetCurrentChunkFromIndex(int index) // Must not call this unless lowerBounds and UpperBounds are allocated
        {
            if (iterateForward)
            {
                // Scan forward first
                for (int i = currentChunkIndex + 1; i < upperBounds!.Length; i++)
                {
                    if (index >= lowerBounds![i] && index <= upperBounds[i])
                    {
                        SetChunk(i);
                        return;
                    }
                }
                for (int i = currentChunkIndex - 1; i >= 0; i--)
                {
                    if (index >= lowerBounds![i] && index <= upperBounds[i])
                    {
                        SetChunk(i);
                        return;
                    }
                }
            }
            else
            {
                // Scan backward first
                for (int i = currentChunkIndex - 1; i >= 0; i--)
                {
                    if (index >= lowerBounds![i] && index <= upperBounds![i])
                    {
                        SetChunk(i);
                        return;
                    }
                }
                for (int i = currentChunkIndex + 1; i < upperBounds!.Length; i++)
                {
                    if (index >= lowerBounds![i] && index <= upperBounds[i])
                    {
                        SetChunk(i);
                        return;
                    }
                }
            }
        }

        private void SetChunk(int chunkIndex) // Must not call this unless lowerBounds and UpperBounds are allocated
        {
            int index = -1;
            foreach (var chunk in stringBuilder.GetChunks())
            {
                index++;
                if (index == chunkIndex)
                {
                    currentChunk = chunk;
                    currentLowerBound = lowerBounds![index];
                    currentUpperBound = upperBounds![index];
                    currentChunkIndex = chunkIndex;
                    return;
                }
            }
        }

        public void Reset()
        {
            if (lowerBounds != null)
            {
                int chunkIndex = iterateForward ? 0 : lowerBounds.Length - 1;
                SetChunk(chunkIndex);
            }
        }

        public void Reset(bool iterateForward)
        {
            this.iterateForward = iterateForward;
            Reset();
        }

        public bool IterateForward => iterateForward;

        public char this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                return currentChunk.Span[index - currentLowerBound];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                unsafe
                {
                    using var handle = currentChunk.Pin();
                    char* pointer = (char*)handle.Pointer;
                    pointer[index - currentLowerBound] = value;
                }
            }
        }

        private static class SR
        {
            public const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the string/array/collection.";
        }
    }


    internal ref struct StringBuilderIndexer2 // With inner struct instead of class
    {
        private readonly StringBuilder stringBuilder;
        private readonly List<MemoryBounds>? chunks;
        private ReadOnlyMemory<char> currentChunk;
        private int currentChunkIndex;
        private int currentLowerBound;
        private int currentUpperBound;
        private bool iterateForward;

        public StringBuilderIndexer2(StringBuilder stringBuilder, bool iterateForward = true)
        {
            this.stringBuilder = stringBuilder ?? throw new ArgumentNullException(nameof(stringBuilder));
            this.iterateForward = iterateForward;
            chunks = null;
            bool first = true;
            int lowerBound = 0;
            int upperBound = -1;
            currentChunkIndex = 0;
            currentLowerBound = lowerBound;
            currentUpperBound = upperBound;
            currentChunk = null;

            foreach (var chunk in stringBuilder.GetChunks())
            {
                lowerBound += upperBound + 1;
                upperBound += chunk.Length;
                if (first)
                {
                    currentChunkIndex = 0;
                    currentLowerBound = lowerBound;
                    currentUpperBound = upperBound;
                    currentChunk = chunk;
                    first = false;
                }
                else
                {
                    if (chunks is null)
                    {
                        chunks = new List<MemoryBounds>();
                        chunks.Add(new MemoryBounds(this.currentChunk, currentLowerBound, currentUpperBound));
                    }
                    chunks.Add(new MemoryBounds(chunk, lowerBound, upperBound));
                }
            }
            Reset();
        }

        private void SetCurrentChunkFromIndex(int index)
        {
            bool found = false;
            if (iterateForward)
            {
                while (index > currentUpperBound)
                {
                    found = true;
                    if (chunks != null)
                    {
                        currentChunkIndex++;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
                if (found) return;
                while (index < currentLowerBound)
                {
                    if (chunks != null)
                    {
                        currentChunkIndex--;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
            }
            else
            {
                while (index < currentLowerBound)
                {
                    found = true;
                    if (chunks != null)
                    {
                        currentChunkIndex--;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
                if (found) return;
                while (index > currentUpperBound)
                {
                    if (chunks != null)
                    {
                        currentChunkIndex++;
                        SetChunk(chunks[currentChunkIndex]);
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                    }
                }
            }
        }

        private void SetChunk(MemoryBounds chunk)
        {
            currentChunk = chunk.Chunk;
            currentLowerBound = chunk.LowerBound;
            currentUpperBound = chunk.UpperBound;
        }

        public void Reset()
        {
            if (chunks != null)
            {
                var chunk = iterateForward ? chunks[0] : chunks[^1];
                SetChunk(chunk);
                currentChunkIndex = iterateForward ? 0 : chunks.Count - 1;
            }
        }

        public void Reset(bool iterateForward)
        {
            this.iterateForward = iterateForward;
            Reset();
        }

        public bool IterateForward => iterateForward;

        public char this[int index]
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                return currentChunk.Span[index - currentLowerBound];
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                if ((uint)index >= (uint)stringBuilder.Length)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), index, SR.ArgumentOutOfRange_Index);
                }

                if (index < currentLowerBound || index > currentUpperBound)
                {
                    SetCurrentChunkFromIndex(index);
                }

                unsafe
                {
                    using var handle = currentChunk.Pin();
                    char* pointer = (char*)handle.Pointer;
                    pointer[index - currentLowerBound] = value;
                }
            }
        }

        private struct MemoryBounds
        {
            public MemoryBounds(ReadOnlyMemory<char> chunk, int lowerBound, int upperBound)
            {
                Chunk = chunk;
                LowerBound = lowerBound;
                UpperBound = upperBound;
            }

            public ReadOnlyMemory<char> Chunk;
            public int LowerBound; // Index of lower bound of the chunk relative to the beginning of the StringBuilder
            public int UpperBound; // Index of uppser bound of the chunk relative to the beginning of the StringBuilder
        }

        private static class SR
        {
            public const string ArgumentOutOfRange_Index = "Index was out of range. Must be non-negative and less than the size of the string/array/collection.";
        }
    }
}
