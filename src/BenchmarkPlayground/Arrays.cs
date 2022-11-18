using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground
{
    public static class Arrays
    {
        /// <summary>
        /// Returns a hash code based on the contents of the given array. For any two
        /// <see cref="byte"/> arrays <c>a</c> and <c>b</c>, if
        /// <c>Arrays.Equals(b)</c> returns <c>true</c>, it means
        /// that the return value of <c>Arrays.GetHashCode(a)</c> equals <c>Arrays.GetHashCode(b)</c>.
        /// </summary>
        /// <param name="array">The array whose hash code to compute.</param>
        /// <returns>The hash code for <paramref name="array"/>.</returns>
        public static int GetHashCode(byte[] array)
        {
            if (array == null)
                return 0;
            int hashCode = 1, arrayLength = array.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                // the hash code value for integer value is integer value itself
                hashCode = 31 * hashCode + array[i];
            }
            return hashCode;
        }

        /// <summary>
        /// Returns a hash code based on the contents of the given array. For any two
        /// <see cref="byte"/> arrays <c>a</c> and <c>b</c>, if
        /// <c>Arrays.Equals(b)</c> returns <c>true</c>, it means
        /// that the return value of <c>Arrays.GetHashCode(a)</c> equals <c>Arrays.GetHashCode(b)</c>.
        /// </summary>
        /// <param name="array">The array whose hash code to compute.</param>
        /// <returns>The hash code for <paramref name="array"/>.</returns>
        public static int GetHashCode2(byte[] array)
        {
            if (array == null)
                return 0;
            int hashCode = 1;
            foreach (var element in array)
            {
                // the hash code value for integer value is integer value itself
                hashCode = 31 * hashCode + element;
            }
            return hashCode;
        }
    }
}
