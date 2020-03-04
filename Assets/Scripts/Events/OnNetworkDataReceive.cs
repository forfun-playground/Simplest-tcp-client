using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkDataReceive", menuName = "Events/OnNetworkDataReceive", order = 50)]
    public class OnNetworkDataReceive : GameEvent<OnNetworkDataReceive.Args>
    {
        public struct Args { public byte[] bytearray; }
    }
}