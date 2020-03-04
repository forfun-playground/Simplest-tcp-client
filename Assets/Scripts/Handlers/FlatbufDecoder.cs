using FlatBuffers;
using forfun.sandbox.uwns.util.pack.flat;
using Pipeline;

namespace Handlers
{
    public class FlatbufDecoder : IInboundMessageDecoder<Packet>
    {
        public Packet Decode(byte[] bytearray)
        {
            var byteBuffer = new ByteBuffer(bytearray);
            return Packet.GetRootAsPacket(byteBuffer);
        }
    }
}