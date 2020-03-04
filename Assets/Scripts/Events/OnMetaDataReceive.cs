using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnMetaDataReceive", menuName = "Events/OnMetaDataReceive", order = 50)]
    public class OnMetaDataReceive : GameEvent<Metadata> { }
}