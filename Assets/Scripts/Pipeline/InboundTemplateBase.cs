using System.Collections.Generic;

namespace Pipeline
{
    public class InboundTemplateBase<TMetadata, TMessage> : IInboundTemplate<TMetadata>
    {
        private readonly IInboundFrameDecoder _frameDecoder;
        private readonly IInboundMessageDecoder<TMessage> _messageDecoder;
        private readonly IInboundMessageHandler<TMessage, TMetadata> _messageHandler;

        public InboundTemplateBase(
            IInboundFrameDecoder frameDecoder,
            IInboundMessageDecoder<TMessage> messageDecoder,
            IInboundMessageHandler<TMessage, TMetadata> messageHandler
        )
        {
            this._frameDecoder = frameDecoder;
            this._messageDecoder = messageDecoder;
            this._messageHandler = messageHandler;
        }

        public TMetadata[] Translate(byte[] bytearray)
        {
            _frameDecoder.Decode(bytearray);
            var listMetadata = new List<TMetadata>();
            while (_frameDecoder.HasFrame())
            {
                var frame = _frameDecoder.GetFrame();
                var message = _messageDecoder.Decode(frame);
                var metadata = _messageHandler.Handle(message);
                listMetadata.Add(metadata);
            }
            return listMetadata.ToArray();
        }
    }
}