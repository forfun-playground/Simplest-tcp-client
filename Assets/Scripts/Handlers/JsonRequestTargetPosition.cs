using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class JsonRequestTargetPosition : OutboundMessageHandlerBase<Packet, Metadata>
    {
        public override bool IsAccept(Metadata meta)
        {
            return meta is TargetPosition;
        }

        public override Packet Process(Metadata meta)
        {
            var target = meta as TargetPosition;
            var json = JsonConvert.SerializeObject(target);
            return new Packet() { type = Packet.MessageType.TargetPositionRequest, message = json };
        }
    }
}