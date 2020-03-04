using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Proto;
using Google.Protobuf;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class ProtobufEncoder : IOutboundMessageEncoder<Message>
    {
        public byte[] Encode(Message message)
        {
            return MessageExtensions.ToByteArray(message);
        }
    }
}
