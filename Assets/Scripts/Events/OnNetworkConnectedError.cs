using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnectedError", menuName = "Events/OnNetworkConnectedError", order = 50)]
    public class OnNetworkConnectedError : GameEvent<OnNetworkConnectedError.Args>
    {
        public struct Args { public string error; }
    }
}