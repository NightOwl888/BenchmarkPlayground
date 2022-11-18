////using Force.Crc32;
//using J2N;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BenchmarkPlayground.Crc32
//{
//    // Patched return value so it is "buffered"
//    public class BufferedCrc32Algorithm2 : Crc32Algorithm
//    {
//        private bool isComputed = false;
//        private long value;

//        public BufferedCrc32Algorithm2()
//            : base(isBigEndian: false)
//        {
//        }

//        public long Value
//        {
//            get
//            {
//                if (!isComputed)
//                {
//                    HashValue = HashFinal();
//                    value = BitConverter.ToUInt32(HashValue, 0);
//                }

//                return value;
//            }
//        }

//        public void Update(byte value)
//        {
//            HashCore(new byte[] { value }, 0, 1);
//        }

//        public void Update(byte[] buffer, int offset, int length)
//        {
//            HashCore(buffer, offset, length);
//        }

//        public void Update(byte[] buffer)
//        {
//            Update(buffer, 0, buffer.Length);
//        }

//        public override void Initialize()
//        {
//            isComputed = false;

//            value = 0;

//            base.Initialize();
//        }

//        protected override void HashCore(byte[] input, int offset, int length)
//        {
//            isComputed = false;

//            base.HashCore(input, offset, length);
//        }

//        protected override byte[] HashFinal()
//        {
//            isComputed = true;

//            return base.HashFinal();
//        }
//    }
//}
