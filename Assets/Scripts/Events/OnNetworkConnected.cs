using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnected", menuName = "Events/OnNetworkConnected", order = 50)]
    public class OnNetworkConnected : GameEvent<OnNetworkConnected.Args>
    {
        public struct Args { public object stateObject; }
    }
}