using forfun.sandbox.uwns.util.pack.json;
using Meta;
using Newtonsoft.Json;
using Pipeline;

namespace Handlers
{

    public class JsonResponseEnterWorld : InboundMessageHandlerBase<Packet, Metadata>
    {
        public override bool IsAccept(Packet packet)
        {
            return packet.type == Packet.MessageType.EnterWorldResponse;
        }

        public override Metadata Process(Packet packet)
        {
            return JsonConvert.DeserializeObject<EnterWorld>(packet.message);
        }
    }
}