using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnect", menuName = "Events/OnNetworkConnect", order = 50)]
    public class OnNetworkConnect : GameEvent<OnNetworkConnect.Args>
    {
        public struct Args { public object stateObject; }
    }
}