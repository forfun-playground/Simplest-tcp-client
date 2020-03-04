using System;
using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnNetworkConnectedError", menuName = "Events/OnNetworkConnectedError", order = 50)]
    public class OnNetworkConnectedError : GameEvent<OnNetworkConnectedError.Args>
    {
        public struct Args { public string error; }
    }
}