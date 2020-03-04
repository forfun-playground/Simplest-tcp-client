using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Meta
{
    public class Metadata
    {
        public class Vector
        {
            [JsonProperty("x")]  public float X;
            [JsonProperty("y")]public float Y;
        }
    }
}
