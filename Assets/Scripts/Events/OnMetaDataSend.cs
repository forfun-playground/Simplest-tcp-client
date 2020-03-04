using Meta;
using Misc;
using UnityEngine;

namespace Events
{
    [CreateAssetMenu(fileName = "OnMetaDataSend", menuName = "Events/OnMetaDataSend", order = 50)]
    public class OnMetaDataSend : GameEvent<Metadata> { }
}