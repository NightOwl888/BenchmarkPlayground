using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground.Crc32
{
    /// <summary>
    /// Contains conversion support elements such as classes, interfaces and static methods.
    /// </summary>
    internal interface IChecksum
    {
        void Reset();

        void Update(int b);

        void Update(byte[] b);

        void Update(byte[] b, int offset, int length);

        long Value { get; }
    }

    internal class CRC32 : IChecksum
    {
        private static readonly uint[] crcTable = InitializeCRCTable();

        private static uint[] InitializeCRCTable()
        {
            uint[] crcTable = new uint[256];
            for (uint n = 0; n < 256; n++)
            {
                uint c = n;
                for (int k = 8; --k >= 0;)
                {
                    if ((c & 1) != 0)
                        c = 0xedb88320 ^ (c >> 1);
                    else
                        c = c >> 1;
                }
                crcTable[n] = c;
            }
            return crcTable;
        }

        private uint crc = 0;

        public long Value => crc & 0xffffffffL;

        public void Reset()
        {
            crc = 0;
        }

        public void Update(int bval)
        {
            uint c = ~crc;
            c = crcTable[(c ^ bval) & 0xff] ^ (c >> 8);
            crc = ~c;
        }

        public void Update(byte[] buf, int off, int len)
        {
            uint c = ~crc;
            while (--len >= 0)
                c = crcTable[(c ^ buf[off++]) & 0xff] ^ (c >> 8);
            crc = ~c;
        }

        public void Update(byte[] buf)
        {
            Update(buf, 0, buf.Length);
        }
    }
}
