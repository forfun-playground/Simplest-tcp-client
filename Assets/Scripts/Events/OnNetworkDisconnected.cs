using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkDisconnected", menuName = "Events/OnNetworkDisconnected", order = 50)]
    public class OnNetworkDisconnected : GameEvent<OnNetworkDisconnected.Args>
    {
        public struct Args { }
    }
}