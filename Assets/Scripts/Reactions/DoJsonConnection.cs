using ForFun.Playground.SimpleTcpClient.Events;
using ForFun.Playground.SimpleTcpClient.Handlers;
using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Misc;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using ForFun.Playground.SimpleTcpClient.Scheme.Json;
using UnityEngine;

namespace ForFun.Playground.SimpleTcpClient.Reactions
{
    public class DoJsonConnection : GameEventAction<ChannelPacktype.Pack>
    {
        [SerializeField] private OnBeginConnection onBeginConnection = default;
        [SerializeField] private OnNetworkConnect onNetworkConnect = default;
        protected override GameEvent<ChannelPacktype.Pack> GameEvent => onBeginConnection;

        protected override void Action(ChannelPacktype.Pack args)
        {
            if (args == ChannelPacktype.Pack.Json)
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
                    new JsonDecoder(),
                    new JsonResponseEnterWorld().SetNext(new JsonResponseSnapshot()).GetFirst()
                ),
                OutboundTemplate = new OutboundTemplateBase<Metadata, Packet>(
                    new FrameEncoder(),
                    new JsonEncoder(),
                    new JsonRequestTargetPosition().GetFirst()
                )
            };
            onNetworkConnect.Raise(new OnNetworkConnect.Args() { stateObject = channelState });
        }
    }
}