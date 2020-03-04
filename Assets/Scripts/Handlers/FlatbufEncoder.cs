using FlatBuffers;
using Pipeline;

namespace Handlers
{
    public class FlatbufEncoder : IOutboundMessageEncoder<FlatBufferBuilder>
    {
        public byte[] Encode(FlatBufferBuilder builder)
        {
            return builder.DataBuffer.ToSizedArray();
        }
    }
}
