using forfun.sandbox.uwns.util.pack.json;
using Meta;
using Newtonsoft.Json;
using Pipeline;

namespace Handlers
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