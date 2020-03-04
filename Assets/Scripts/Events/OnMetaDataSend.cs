using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnMetaDataSend", menuName = "Events/OnMetaDataSend", order = 50)]
    public class OnMetaDataSend : GameEvent<Metadata> { }
}