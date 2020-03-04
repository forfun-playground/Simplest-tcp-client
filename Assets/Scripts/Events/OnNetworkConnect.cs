using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnect", menuName = "Events/OnNetworkConnect", order = 50)]
    public class OnNetworkConnect : GameEvent<OnNetworkConnect.Args>
    {
        public struct Args { public object stateObject; }
    }
}