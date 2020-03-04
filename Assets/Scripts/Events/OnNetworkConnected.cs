using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnected", menuName = "Events/OnNetworkConnected", order = 50)]
    public class OnNetworkConnected : GameEvent<OnNetworkConnected.Args>
    {
        public struct Args { public object stateObject; }
    }
}