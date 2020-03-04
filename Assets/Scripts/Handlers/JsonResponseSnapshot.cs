using forfun.sandbox.uwns.util.pack.json;
using Meta;
using Newtonsoft.Json;
using Pipeline;

namespace Handlers
{
    public class JsonResponseSnapshot : InboundMessageHandlerBase<Packet, Metadata>
    {
        public override bool IsAccept(Packet packet)
        {
            return packet.type == Packet.MessageType.SnapshotResponse;
        }

        public override Metadata Process(Packet packet)
        {
            return JsonConvert.DeserializeObject<Snapshot>(packet.message);
        }
    }
}