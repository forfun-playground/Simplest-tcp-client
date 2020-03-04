using FlatBuffers;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using forfun.sandbox.uwns.util.pack.flat;

namespace ForFun.Playground.SimpleTcpClient.Handlers
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