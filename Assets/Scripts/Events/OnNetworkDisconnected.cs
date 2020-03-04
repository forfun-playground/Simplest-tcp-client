using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkDisconnected", menuName = "Events/OnNetworkDisconnected", order = 50)]
    public class OnNetworkDisconnected : GameEvent<OnNetworkDisconnected.Args>
    {
        public struct Args { }
    }
}