using System;
using Pipeline;

namespace Handlers
{
    public class FrameDecoder : IInboundFrameDecoder
    {
        private int _currentsize;
        private const int Maxsize = 0x20000;
        private readonly byte[] _bufferarray = new byte[Maxsize];

        public void Decode(byte[] bytearray)
        {
            Array.Copy(bytearray, 0, _bufferarray, _currentsize, bytearray.Length);
            _currentsize += bytearray.Length;
        }

        public bool HasFrame()
        {
            var frameLength = _bufferarray[0] << 8 | _bufferarray[1];
            return frameLength <= _currentsize;
        }

        public byte[] GetFrame()
        {
            if (HasFrame())
            {
                var frameLength = _bufferarray[0] << 8 | _bufferarray[1];
                var frameArray = new byte[frameLength - 2];
                Array.Copy(_bufferarray, 2, frameArray, 0, frameLength - 2);
                _currentsize -= frameLength;
                Array.Copy(_bufferarray, frameLength, _bufferarray, 0, _currentsize);
                return frameArray;
            }
            throw new InvalidOperationException("missing frame in the array");
        }
    }
}