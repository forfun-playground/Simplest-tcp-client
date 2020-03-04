using FlatBuffers;
using ForFun.Playground.SimpleTcpClient.Pipeline;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class FlatbufEncoder : IOutboundMessageEncoder<FlatBufferBuilder>
    {
        public byte[] Encode(FlatBufferBuilder builder)
        {
            return builder.DataBuffer.ToSizedArray();
        }
    }
}
