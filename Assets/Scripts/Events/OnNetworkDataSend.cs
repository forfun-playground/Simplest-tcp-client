using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkDataSend", menuName = "Events/OnNetworkDataSend", order = 50)]
    public class OnNetworkDataSend :  GameEvent<OnNetworkDataSend.Args>
    {
        public struct Args { public byte[] bytearray; }
    }
}
