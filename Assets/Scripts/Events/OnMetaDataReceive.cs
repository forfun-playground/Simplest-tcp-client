using Meta;
using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnMetaDataReceive", menuName = "Events/OnMetaDataReceive", order = 50)]
    public class OnMetaDataReceive : GameEvent<Metadata> { }
}