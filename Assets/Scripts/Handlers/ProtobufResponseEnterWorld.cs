using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Meta;
using Pipeline;

namespace Handlers
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