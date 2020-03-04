using System.Text;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Handlers
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