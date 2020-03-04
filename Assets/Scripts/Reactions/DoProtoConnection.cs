using Events;
using Forfun.Sandbox.Uwns.Client.Sheme.Proto;
using Handlers;
using Meta;
using Misc;
using Pipeline;
using UnityEngine;

namespace Reactions
{
    public class DoProtoConnection : GameEventAction<ChannelPacktype.Pack>
    {
        [SerializeField] private OnBeginConnection onBeginConnection = default;
        [SerializeField] private OnNetworkConnect onNetworkConnect = default;
        protected override GameEvent<ChannelPacktype.Pack> GameEvent => onBeginConnection;

        protected override void Action(ChannelPacktype.Pack packtype)
        {
            if (packtype == ChannelPacktype.Pack.Protobuf)
            {
                DoNetworkConnect(packtype);
            }
        }

        private void DoNetworkConnect(ChannelPacktype.Pack packtype)
        {
            var channelState = new ChannelState()
            {
                ChannelPacktype = new ChannelPacktype(packtype),
                InboundTemplate = new InboundTemplateBase<Metadata, Message>(
                    new FrameDecoder(),
                    new ProtobufDecoder(),
                    new ProtobufResponseEnterWorld()
                        .SetNext(new ProtobufResponseSnapshot()).GetFirst()
                ),
                OutboundTemplate = new OutboundTemplateBase<Metadata, Message>(
                    new FrameEncoder(),
                    new ProtobufEncoder(),
                    new ProtobufRequestTargetPosition().GetFirst()
                )
            };
            onNetworkConnect.Raise(new OnNetworkConnect.Args() { stateObject = channelState });
        }

    }
}