﻿using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;
using forfun.sandbox.uwns.util.pack.flat;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class FlatbufResponseEnterWorld : InboundMessageHandlerBase<Packet, Metadata>
    {
        public override bool IsAccept(Packet pkt)
        {
            return pkt.DataType == Message.EnterWorldResponse;
        }

        public override Metadata Process(Packet pkt)
        {
            var response = pkt.Data<EnterWorldResponse>().Value;
            var uid =  response.Uid;
            return new EnterWorld() { Uid = uid };            
        }
    }
}