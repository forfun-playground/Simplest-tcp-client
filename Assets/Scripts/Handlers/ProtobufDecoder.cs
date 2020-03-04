using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Proto;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class ProtobufDecoder : IInboundMessageDecoder<Message>
    {
        public Message Decode(byte[] bytearray)
        {
            return Message.Parser.ParseFrom(bytearray);
        }
    }
}