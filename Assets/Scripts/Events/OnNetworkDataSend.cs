using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Events
{
    [CreateAssetMenu(fileName = "OnNetworkDataSend", menuName = "Events/OnNetworkDataSend", order = 50)]
    public class OnNetworkDataSend :  GameEvent<OnNetworkDataSend.Args>
    {
        public struct Args { public byte[] bytearray; }
    }
}
