using Handlers;
using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnBeginConnection", menuName = "Events/OnBeginConnection", order = 50)]
    public class OnBeginConnection : GameEvent<ChannelPacktype.Pack> { }
}