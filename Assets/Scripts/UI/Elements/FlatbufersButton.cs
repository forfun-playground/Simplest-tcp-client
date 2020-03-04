using ForFun.Playground.SimpleTcpClient.Events;
using ForFun.Playground.SimpleTcpClient.Handlers;
using ForFun.Playground.SimpleTcpClient.Misc;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.UI.Elements
{
    public class FlatbufersButton : ButtonActionBase
    {
        [SerializeField] private OnBeginConnection onBeginConnection = default;

        protected override void Action()
        {
            onBeginConnection.Raise(ChannelPacktype.Pack.Flatbuffer);
        }
    }
}