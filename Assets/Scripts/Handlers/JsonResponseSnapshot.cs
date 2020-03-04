using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Handlers
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