using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Google.Protobuf;
using Pipeline;

namespace Handlers
{
    public class ProtobufEncoder : IOutboundMessageEncoder<Message>
    {
        public byte[] Encode(Message message)
        {
            return MessageExtensions.ToByteArray(message);
        }
    }
}
