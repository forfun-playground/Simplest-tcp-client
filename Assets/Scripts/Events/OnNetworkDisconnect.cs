using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkDisconnect", menuName = "Events/OnNetworkDisconnect", order = 50)]
    public class OnNetworkDisconnect : GameEvent<OnNetworkDisconnect.Args>
    {
        public struct Args { }
    }
}