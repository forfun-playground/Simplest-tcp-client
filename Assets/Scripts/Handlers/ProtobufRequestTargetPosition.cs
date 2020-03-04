using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Proto;

namespace ForFun.Playground.SimpleTcpClient.Handlers
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