using System.Text;
using forfun.sandbox.uwns.util.pack.json;
using Newtonsoft.Json;
using Pipeline;

namespace Handlers
{
    public class JsonDecoder : IInboundMessageDecoder<Packet>
    {
        public Packet Decode(byte[] bytearray)
        {
            var json = Encoding.UTF8.GetString(bytearray);
            return JsonConvert.DeserializeObject<Packet>(json);
        }
    }
}