using Events;
using FlatBuffers;
using forfun.sandbox.uwns.util.pack.flat;
using Handlers;
using Meta;
using Misc;
using Pipeline;
using UnityEngine;

namespace Reactions
{
    public class DoFlatConnection : GameEventAction<ChannelPacktype.Pack>
    {
        [SerializeField] private OnBeginConnection onBeginConnection = default;
        [SerializeField] private OnNetworkConnect onNetworkConnect = default;
        protected override GameEvent<ChannelPacktype.Pack> GameEvent => onBeginConnection;

        protected override void Action(ChannelPacktype.Pack args)
        {
            if (args == ChannelPacktype.Pack.Flatbuffer)
            {
                DoNetworkConnect(args);
            }
        }

        private void DoNetworkConnect(ChannelPacktype.Pack packtype)
        {
            var channelState = new ChannelState()
            {
                ChannelPacktype = new ChannelPacktype(packtype),
                InboundTemplate = new InboundTemplateBase<Metadata, Packet>(
                    new FrameDecoder(),
                    new FlatbufDecoder(),
                    new FlatbufResponseEnterWorld()
                        .SetNext(new FlatbufResponseSnapshot()).GetFirst()
                ),
                OutboundTemplate = new OutboundTemplateBase<Metadata, FlatBufferBuilder>(
                    new FrameEncoder(),
                    new FlatbufEncoder(),
                    new FlatbufRequestTargetPosition().GetFirst()
                )
            };
            onNetworkConnect.Raise(new OnNetworkConnect.Args() { stateObject = channelState });
        }
    }
}