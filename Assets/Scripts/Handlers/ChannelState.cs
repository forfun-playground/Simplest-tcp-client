using ForFun.Playground.SimpleTcpClient.Meta;
using ForFun.Playground.SimpleTcpClient.Pipeline;

namespace ForFun.Playground.SimpleTcpClient.Handlers
{
    public class ChannelState
    {
        public ChannelPacktype ChannelPacktype;
        public IInboundTemplate<Metadata> InboundTemplate;
        public IOutboundTemplate<Metadata> OutboundTemplate;
    }
}