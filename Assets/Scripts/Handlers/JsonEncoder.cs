using System.Text;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class JsonEncoder : IOutboundMessageEncoder<Packet>
    {
        public byte[] Encode(Packet packet)
        {
            var json = JsonConvert.SerializeObject(packet);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}