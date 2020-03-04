using Newtonsoft.Json;

namespace ForFun.Playground.SimpleTcpClient.Meta
{
    public class TargetPosition : Metadata
    {
        [JsonProperty("position")] public Vector Position;
    }
}