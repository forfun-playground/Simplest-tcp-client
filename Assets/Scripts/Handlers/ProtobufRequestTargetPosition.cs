using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Meta;
using Pipeline;

namespace Handlers
{
    public class ProtobufRequestTargetPosition : OutboundMessageHandlerBase<Message, Metadata>
    {
        public override bool IsAccept(Metadata meta)
        {
            return meta is TargetPosition;
        }

        public override Message Process(Metadata meta)
        {
            var target = meta as TargetPosition;
            return new Message
            {
                TargetPositionRequest = new TargetPositionRequest
                {
                    Position = new Vector()
                    {
                        X = target.Position.X,
                        Y = target.Position.Y
                    }
                }
            };
        }
    }
}