using Events;
using Handlers;
using Misc;
using UnityEngine;

namespace UI.Elements
{
    public class ProtobufButton : ButtonActionBase
    {
        [SerializeField] private OnBeginConnection onBeginConnection = default;

        protected override void Action()
        {
            onBeginConnection.Raise(ChannelPacktype.Pack.Protobuf);
        }
    }
}