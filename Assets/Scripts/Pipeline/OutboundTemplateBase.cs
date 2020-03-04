namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public class OutboundTemplateBase<TMetadata, TMessage> : IOutboundTemplate<TMetadata>
    {
        private readonly IOutboundMessageHandler<TMessage, TMetadata> _messageHandler;
        private readonly IOutboundMessageEncoder<TMessage> _messageEncoder;
        private readonly IOutboundFrameEncoder _frameEncoder;

        public OutboundTemplateBase(
            IOutboundFrameEncoder frameEncoder,
            IOutboundMessageEncoder<TMessage> messageEncoder,
            IOutboundMessageHandler<TMessage, TMetadata> messageHandler
        )
        {
            this._messageHandler = messageHandler;
            this._messageEncoder = messageEncoder;
            this._frameEncoder = frameEncoder;
        }

        public byte[] Translate(TMetadata metadata)
        {
            var message = _messageHandler.Handle(metadata);
            var bytearray = _messageEncoder.Encode(message);
            var framearray = _frameEncoder.Encode(bytearray);
            return framearray;
        }
    }
}