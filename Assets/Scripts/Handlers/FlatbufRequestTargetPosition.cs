using FlatBuffers;
using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using forfun.sandbox.uwns.util.pack.flat;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class FlatbufRequestTargetPosition : OutboundMessageHandlerBase<FlatBufferBuilder, Metadata>
    {
        public override bool IsAccept(Metadata meta)
        {
            return meta is TargetPosition;
        }

        public override FlatBufferBuilder Process(Metadata meta)
        {
            var target = meta as TargetPosition;
            var builder = new FlatBufferBuilder(1024);
            var positionOffset = Vector.CreateVector(builder, target.Position.X, target.Position.Y);
            TargetPositionRequest.StartTargetPositionRequest(builder);
            TargetPositionRequest.AddPosition(builder, positionOffset);
            var response = TargetPositionRequest.EndTargetPositionRequest(builder);
            var packet = Packet.CreatePacket(builder, Message.TargetPositionRequest, response.Value);
            Packet.FinishPacketBuffer(builder, packet);
            return builder;
        }
    }
}