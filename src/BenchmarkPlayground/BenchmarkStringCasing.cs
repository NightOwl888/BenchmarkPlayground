using BenchmarkDotNet.Attributes;
using J2N;
using RandomizedTesting.Generators;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BenchmarkPlayground
{
    [MemoryDiagnoser]
    public class BenchmarkStringCasing
    {
        public const int Iterations = 100000;

        private const int MAX_STACK_LIMIT = 1024;
        private const string ShortString = "FOOD";
        private const string MediumString = "EveryBodyIsAWinnerInLasVegasExceptMe";
        private const string LongString = "HSSFLDKKLSKLFJLSfaljdfafkSFLKLSlasfnwwoidcSJDFDNIIIDUSLDFNSAFELSDFENLSDKadasdlewngsHYHALKNasdfljaADFHLKSJFLSDKFHadfalkfaHSDFKSHaasldfkHSFDKLSLJSadfsakajdfUIEOejVNalsdnaeNSFNSLFNSLEEasfalewSSDFKNLESFwfnalkdflenfalkngaldefnaelfnlknadlgnkeanaflealkgneknFSFLJFLSDKFNENELFakdlfaksdfEFNELNFLEKNFSLKFNafdnalfnlakfnlanfldknaldkfnalfSFLKFLKSDFJSLFENlknlkfkladflaHSSFLDKKLSKLFJLSfaljdfafkSFLKLSlasfnwwoidcSJDFDNIIIDUSLDFNSAFELSDFENLSDKadasdlewngsHYHALKNasdfljaADFHLKSJFLSDKFHadfalkfaHSDFKSHaasldfkHSFDKLSLJSadfsakajdfUIEOejVNalsdnaeNSFNSLFNSLEEasfalewSSDFKNLESFwfnalkdflenfalkngaldefnaelfnlknadlgnkeanaflealkgneknFSFLJFLSDKFNENELFakdlfaksdfEFNELNFLEKNFSLKFNafdnalfnlakfnlanfldknaldkfnalfSFLKFLKSDFJSLFENlknlkfkladflaHSSFLDKKLSKLFJLSfaljdfafkSFLKLSlasfnwwoidcSJDFDNIIIDUSLDFNSAFELSDFENLSDKadasdlewngsHYHALKNasdfljaADFHLKSJFLSDKFHadfalkfaHSDFKSHaasldfkHSFDKLSLJSadfsakajdfUIEOejVNalsdnaeNSFNSLFNSLEEasfalewSSDFKNLESFwfnalkdflenfalkngaldefnaelfnlknadlgnkeanaflealkgneknFSFLJFLSDKFNENELFakdlfaksdfEFNELNFLEKNFSLKFNafdnalfnlakfnlanfldknaldkfnalfSFLKFLKSDFJSLFENlknlkfkladfla";
        private static char[] ShortBuffer;
        private static char[] MediumBuffer;
        private static char[] LongBuffer;

        private static Randomizer Random;
        private static IList<char[]> TestStrings;

        [GlobalSetup]
        public void GlobalSetup()
        {
            Random = new Randomizer(345);
            var strings = new List<char[]>();

            for (int a = 0; a < Iterations; a++)
            {
                string text2;
                if (a % 5 == 0)
                    text2 = LongString;
                else
                    text2 = Random.NextRealisticUnicodeString(LongString.Length, LongString.Length);
                strings.Add(text2.ToCharArray());
            }

            TestStrings = strings.ToArray();
        }


        [IterationSetup]
        public void IterationSetup()
        {
            
        }

        ////[IterationSetup]
        ////public void IterationSetup()
        ////{
        ////    ShortBuffer = ShortString.ToCharArray();
        ////    MediumBuffer = MediumString.ToCharArray();
        ////    LongBuffer = LongString.ToCharArray();
        ////}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Short_Loop()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        ShortBuffer = ShortString.ToCharArray();
        //        int length = ShortBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = ShortBuffer;

        //        // Original (slow) Lucene implementation:
        //        int limit = length - offset;
        //        for (int i = offset; i < limit;)
        //        {
        //            i += Character.ToChars(
        //                Character.ToLower(
        //                    Character.CodePointAt(buffer, i, limit), CultureInfo.InvariantCulture), buffer, i);
        //        }
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Medium_Loop()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        MediumBuffer = MediumString.ToCharArray();
        //        int length = MediumBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = MediumBuffer;

        //        // Original (slow) Lucene implementation:
        //        int limit = length - offset;
        //        for (int i = offset; i < limit;)
        //        {
        //            i += Character.ToChars(
        //                Character.ToLower(
        //                    Character.CodePointAt(buffer, i, limit), CultureInfo.InvariantCulture), buffer, i);
        //        }
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Long_Loop()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        LongBuffer = LongString.ToCharArray();
        //        int length = LongBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = LongBuffer;

        //        // Original (slow) Lucene implementation:
        //        int limit = length - offset;
        //        for (int i = offset; i < limit;)
        //        {
        //            i += Character.ToChars(
        //                Character.ToLower(
        //                    Character.CodePointAt(buffer, i, limit), CultureInfo.InvariantCulture), buffer, i);
        //        }
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Short_CopyTo()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        ShortBuffer = ShortString.ToCharArray();
        //        int length = ShortBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = ShortBuffer;

        //        // Slight optimization, eliminating a few method calls internally
        //        CultureInfo.InvariantCulture.TextInfo
        //            .ToLower(new string(buffer, offset, length))
        //            .CopyTo(0, buffer, offset, length);
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Medium_CopyTo()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        MediumBuffer = MediumString.ToCharArray();
        //        int length = MediumBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = MediumBuffer;

        //        // Slight optimization, eliminating a few method calls internally
        //        CultureInfo.InvariantCulture.TextInfo
        //            .ToLower(new string(buffer, offset, length))
        //            .CopyTo(0, buffer, offset, length);
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Long_CopyTo()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        LongBuffer = LongString.ToCharArray();
        //        int length = LongBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = LongBuffer;

        //        // Slight optimization, eliminating a few method calls internally
        //        CultureInfo.InvariantCulture.TextInfo
        //            .ToLower(new string(buffer, offset, length))
        //            .CopyTo(0, buffer, offset, length);
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Medium_Rune()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        MediumBuffer = MediumString.ToCharArray();

        //        int position = 0;
        //        Span<char> destination = MediumBuffer.AsSpan();
        //        foreach (Rune rune in MediumBuffer.AsSpan().EnumerateRunes())
        //        {
        //            int runeLength = rune.Utf16SequenceLength;
        //            if (Rune.IsLetter(rune) && !Rune.IsUpper(rune))
        //            {
        //                var d = destination.Slice(position, runeLength);
        //                Rune.ToUpperInvariant(rune).EncodeToUtf16(d);
        //            }

        //            position += runeLength;
        //        }
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Long_Rune()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        LongBuffer = LongString.ToCharArray();

        //        int position = 0;
        //        Span<char> destination = LongBuffer.AsSpan();
        //        foreach (Rune rune in LongBuffer.AsSpan().EnumerateRunes())
        //        {
        //            int runeLength = rune.Utf16SequenceLength;
        //            if (Rune.IsLetter(rune) && !Rune.IsUpper(rune))
        //            {
        //                var d = destination.Slice(position, runeLength);
        //                Rune.ToUpperInvariant(rune).EncodeToUtf16(d);
        //            }

        //            position += runeLength;
        //        }
        //    }
        //}


        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Short_Span()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        ShortBuffer = ShortString.ToCharArray();
        //        int length = ShortBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = ShortBuffer;

        //        // Reduce allocations by using the stack and spans
        //        var source = new ReadOnlySpan<char>(buffer, offset, length);
        //        var destination = buffer.AsSpan(offset, length);
        //        var spare = length <= MAX_STACK_LIMIT ? stackalloc char[length] : new char[length];
        //        source.ToLower(spare, CultureInfo.InvariantCulture);
        //        spare.CopyTo(destination);
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Medium_Span()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        MediumBuffer = MediumString.ToCharArray();
        //        int length = MediumBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = MediumBuffer;

        //        // Reduce allocations by using the stack and spans
        //        var source = new ReadOnlySpan<char>(buffer, offset, length);
        //        var destination = buffer.AsSpan(offset, length);
        //        var spare = length <= MAX_STACK_LIMIT ? stackalloc char[length] : new char[length];
        //        source.ToLower(spare, CultureInfo.InvariantCulture);
        //        spare.CopyTo(destination);
        //    }
        //}

        //[Benchmark]
        ////[IterationCount(Iterations)]
        ////[InvocationCount(Iterations)]
        //public void ToLower_Long_Span()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        LongBuffer = LongString.ToCharArray();
        //        int length = LongBuffer.Length;
        //        int offset = 0;
        //        char[] buffer = LongBuffer;

        //        // Reduce allocations by using the stack and spans
        //        var source = new ReadOnlySpan<char>(buffer, offset, length);
        //        var destination = buffer.AsSpan(offset, length);
        //        var spare = length <= MAX_STACK_LIMIT ? stackalloc char[length] : new char[length];
        //        source.ToLower(spare, CultureInfo.InvariantCulture);
        //        spare.CopyTo(destination);
        //    }
        //}

        //[Benchmark]
        //public void GetHashCode_String_Long_IgnoreCase1()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        GetHashCode(LongString, ignoreCase: true);
        //    }
        //}

        //[Benchmark]
        //public void GetHashCode_String_Long_IgnoreCase2()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        GetHashCode2(LongString, ignoreCase: true);
        //    }
        //}

        //[Benchmark]
        //public void GetHashCode_ReadOnlySpan_Long_IgnoreCase1()
        //{
        //    var span = LongString.AsSpan();
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        GetHashCode(span, ignoreCase: true);
        //    }
        //}

        //[Benchmark]
        //public void GetHashCode_ReadOnlySpan_Long_IgnoreCase2()
        //{
        //    var span = LongString.AsSpan();
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        GetHashCode2(span, ignoreCase: true);
        //    }
        //}


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static int GetHashCode(string text, bool ignoreCase)
        //{
        //    if (text is null)
        //        throw new ArgumentNullException(nameof(text)); // LUCENENET specific - changed from IllegalArgumentException to ArgumentNullException (.NET convention)

        //    int code = 0;
        //    int length = text.Length;
        //    if (ignoreCase)
        //    {
        //        for (int i = 0; i < length;)
        //        {
        //            int codePointAt = Character.CodePointAt(text, i);
        //            code = code * 31 + Character.ToLower(codePointAt, CultureInfo.InvariantCulture); // LUCENENET specific - need to use invariant culture to match Java
        //            i += Character.CharCount(codePointAt);
        //        }
        //    }
        //    else
        //    {
        //        foreach (var ch in text.AsSpan(0, length))
        //            code = code * 31 + ch;
        //    }
        //    return code;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static int GetHashCode2(string text, bool ignoreCase)
        //{
        //    if (text is null)
        //        throw new ArgumentNullException(nameof(text)); // LUCENENET specific - changed from IllegalArgumentException to ArgumentNullException (.NET convention)

        //    int code = 0;
        //    int length = text.Length;
        //    if (ignoreCase)
        //    {
        //        for (int i = 0; i < length;)
        //        {
        //            int codePointAt = Character.CodePointAt(text, i);
        //            code = code * 31 + Character.ToLower(codePointAt, CultureInfo.InvariantCulture); // LUCENENET specific - need to use invariant culture to match Java
        //            i += Character.CharCount(codePointAt);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < length; i++)
        //        {
        //            code = code * 31 + text[i];
        //        }
        //    }
        //    return code;
        //}



        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static int GetHashCode(ReadOnlySpan<char> text, bool ignoreCase) // Preconditions: FEATURE_RUNE, !charUtils.HasBrokenUnicode
        //{
        //    if (text.Length == 0) return 0;
        //    int code = 0;
        //    if (ignoreCase)
        //    {
        //        foreach (Rune rune1 in text.EnumerateRunes())
        //            code = code * 31 + (Rune.IsLower(rune1) ? rune1.Value : Rune.ToLowerInvariant(rune1).Value);
        //    }
        //    else
        //    {
        //        foreach (var ch in text)
        //            code = code * 31 + ch;
        //    }
        //    return code;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private static int GetHashCode2(ReadOnlySpan<char> text, bool ignoreCase) // Preconditions: FEATURE_RUNE, !charUtils.HasBrokenUnicode
        //{
        //    if (text.Length == 0) return 0;
        //    int code = 0;
        //    if (ignoreCase)
        //    {
        //        foreach (Rune rune1 in text.EnumerateRunes())
        //            code = code * 31 + Rune.ToLowerInvariant(rune1).Value;
        //    }
        //    else
        //    {
        //        foreach (var ch in text)
        //            code = code * 31 + ch;
        //    }
        //    return code;
        //}


        //[Benchmark]
        //public void Equals_String_Long_IgnoreCase1()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        Equals(LongString, TestStrings[a], ignoreCase: true);
        //    }
        //}

        //[Benchmark]
        //public void Equals_ReadOnlySpan_Long_IgnoreCase1()
        //{
        //    for (int a = 0; a < Iterations; a++)
        //    {
        //        Equals(LongString.AsSpan(), TestStrings[a], ignoreCase: true);
        //    }
        //}


        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private bool Equals(string text1, char[] text2, bool ignoreCase)
        //{
        //    int length = text1.Length;
        //    if (length != text2.Length)
        //    {
        //        return false;
        //    }
        //    if (ignoreCase)
        //    {
        //        for (int i = 0; i < length;)
        //        {
        //            int codePointAt = Character.CodePointAt(text1, i);
        //            if (Character.ToLower(codePointAt, CultureInfo.InvariantCulture) != Character.CodePointAt(text2, i, text2.Length)) // LUCENENET specific - need to use invariant culture to match Java
        //            {
        //                return false;
        //            }
        //            i += Character.CharCount(codePointAt);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < length; i++)
        //        {
        //            if (text1[i] != text2[i])
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    return true;
        //}

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private bool Equals(ReadOnlySpan<char> text1, ReadOnlySpan<char> text2, bool ignoreCase)
        //{
        //    int length = text1.Length;
        //    if (length != text2.Length)
        //    {
        //        return false;
        //    }
        //    return text1.Equals(text2, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        //}
    }
}
