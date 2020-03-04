using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Handlers
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