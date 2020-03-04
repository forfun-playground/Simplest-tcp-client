using Meta;
using Pipeline;

namespace Handlers
{
    public class ChannelState
    {
        public ChannelPacktype ChannelPacktype;
        public IInboundTemplate<Metadata> InboundTemplate;
        public IOutboundTemplate<Metadata> OutboundTemplate;
    }
}