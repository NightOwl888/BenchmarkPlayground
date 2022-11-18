//using Force.Crc32;
using System;
using System.Collections.Generic;
using System.Text;

namespace BenchmarkPlayground.Crc32
{
    public class BufferedCrc32Algorithm : Crc32Algorithm
    {
        private bool isComputed = false;

        public BufferedCrc32Algorithm()
            : base(isBigEndian: false)
        {
            HashSizeValue = sizeof(uint);
        }

        public long Value
        {
            get
            {
                if (!isComputed)
                {
                    HashValue = HashFinal();
                }

                return BitConverter.ToUInt32(HashValue, 0);
            }
        }

        public void Update(byte value)
        {
            HashCore(new byte[] { value }, 0, 1);
        }

        public void Update(byte[] buffer, int offset, int length)
        {
            HashCore(buffer, offset, length);
        }

        public void Update(byte[] buffer)
        {
            Update(buffer, 0, buffer.Length);
        }

        public override void Initialize()
        {
            HashValue = new byte[]
            {
                0,0,0,0
            };

            base.Initialize();
        }

        protected override void HashCore(byte[] input, int offset, int length)
        {
            isComputed = false;

            base.HashCore(input, offset, length);
        }

        protected override byte[] HashFinal()
        {
            isComputed = true;

            return base.HashFinal();
        }
    }
}
