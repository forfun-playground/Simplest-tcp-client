using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Proto;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class ProtobufResponseEnterWorld : InboundMessageHandlerBase<Message, Metadata>
    {
        public override bool IsAccept(Message msg)
        {
            return msg.RequestCase == Message.RequestOneofCase.EnterWorldResponse;
        }

        public override Metadata Process(Message msg)
        {
            return new EnterWorld() { Uid = msg.EnterWorldResponse.Uid };
        }
    }
}