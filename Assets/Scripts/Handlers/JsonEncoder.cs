using System.Text;
using forfun.sandbox.uwns.util.pack.json;
using Newtonsoft.Json;
using Pipeline;

namespace Handlers
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