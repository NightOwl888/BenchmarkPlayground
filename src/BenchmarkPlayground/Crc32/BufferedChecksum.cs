using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BenchmarkPlayground.Crc32
{
    /// <summary>
    /// Wraps another <see cref="IChecksum"/> with an internal buffer
    /// to speed up checksum calculations.
    /// </summary>
    // LUCENENET TODO: This class was public in Lucene. Marking internal, since
    // a better approach would be to map this to the HashAlgorithm abstract class in .NET
    // instead of using IChecksum from Java. See LUCENENET-637.
    // After this conversion is done, this can be made public again. However, it is
    // now internal so the conversion doesn't introduce a breaking public API change.
    internal class BufferedChecksum : IChecksum
    {
        private readonly IChecksum @in;
        private readonly byte[] buffer;
        private int upto;

        /// <summary>
        /// Default buffer size: 256 </summary>
        public const int DEFAULT_BUFFERSIZE = 256;

        /// <summary>
        /// Create a new <see cref="BufferedChecksum"/> with <see cref="DEFAULT_BUFFERSIZE"/> </summary>
        public BufferedChecksum(IChecksum @in)
            : this(@in, DEFAULT_BUFFERSIZE)
        {
        }

        /// <summary>
        /// Create a new <see cref="BufferedChecksum"/> with the specified <paramref name="bufferSize"/> </summary>
        public BufferedChecksum(IChecksum @in, int bufferSize)
        {
            this.@in = @in;
            this.buffer = new byte[bufferSize];
        }

        public virtual void Update(int b)
        {
            if (upto == buffer.Length)
            {
                Flush();
            }
            buffer[upto++] = (byte)b;
        }

        // LUCENENET specific overload for updating a whole byte[] array
        public virtual void Update(byte[] b)
        {
            Update(b, 0, b.Length);
        }

        public virtual void Update(byte[] b, int off, int len)
        {
            if (len >= buffer.Length)
            {
                Flush();
                @in.Update(b, off, len);
            }
            else
            {
                if (upto + len > buffer.Length)
                {
                    Flush();
                }
                System.Buffer.BlockCopy(b, off, buffer, upto, len);
                upto += len;
            }
        }

        public virtual long Value
        {
            get
            {
                Flush();
                return @in.Value;
            }
        }

        public virtual void Reset()
        {
            upto = 0;
            @in.Reset();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Flush()
        {
            if (upto > 0)
            {
                @in.Update(buffer, 0, upto);
            }
            upto = 0;
        }
    }
}
