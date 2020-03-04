using ForFun.Playground.SimpleTcpClient.Pipeline;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class FrameEncoder : IOutboundFrameEncoder
    {
        public byte[] Encode(byte[] bytearray)
        {
            var outboundArray = new byte[bytearray.Length + 2];
            bytearray.CopyTo(outboundArray, 2);
            outboundArray[0] = (byte) (outboundArray.Length >> 8 & 0xFF);
            outboundArray[1] = (byte) (outboundArray.Length & 0xFF);
            return outboundArray;
        }
    }
}