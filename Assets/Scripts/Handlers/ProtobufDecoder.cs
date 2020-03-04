using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Pipeline;

namespace Handlers
{
    public class ProtobufDecoder : IInboundMessageDecoder<Message>
    {
        public Message Decode(byte[] bytearray)
        {
            return Message.Parser.ParseFrom(bytearray);
        }
    }
}