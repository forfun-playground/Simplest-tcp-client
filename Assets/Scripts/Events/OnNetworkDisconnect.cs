using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkDisconnect", menuName = "Events/OnNetworkDisconnect", order = 50)]
    public class OnNetworkDisconnect : GameEvent<OnNetworkDisconnect.Args>
    {
        public struct Args { }
    }
}