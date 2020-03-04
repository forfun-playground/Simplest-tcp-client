using Newtonsoft.Json;

namespace Meta
{
    public class TargetPosition : Metadata
    {
        [JsonProperty("position")] public Vector Position;
    }
}