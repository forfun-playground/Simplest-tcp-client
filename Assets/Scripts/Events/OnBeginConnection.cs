using ForFun.Playground.SimpleTcpClient.Handlers;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnBeginConnection", menuName = "Events/OnBeginConnection", order = 50)]
    public class OnBeginConnection : GameEvent<ChannelPacktype.Pack> { }
}