using System;

namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public abstract class OutboundMessageHandlerBase<TMessage, TMetadata> : IOutboundMessageHandler<TMessage, TMetadata>
    {
        private IOutboundMessageHandler<TMessage, TMetadata> _prevHandler;
        private IOutboundMessageHandler<TMessage, TMetadata> _nextHandler;

        public void SetPrev(IOutboundMessageHandler<TMessage, TMetadata> handler)
        {
            this._prevHandler = handler;
        }

        public IOutboundMessageHandler<TMessage, TMetadata> SetNext(IOutboundMessageHandler<TMessage, TMetadata> handler)
        {
            handler.SetPrev(this);
            _nextHandler = handler;
            return handler;
        }

        public IOutboundMessageHandler<TMessage, TMetadata> GetFirst()
        {
            return _prevHandler != null ? _prevHandler.GetFirst() : this;
        }

        private bool HasNext() { return _nextHandler != null; }

        public TMessage Handle(TMetadata meta)
        {
            if (IsAccept(meta))
            {
                return Process(meta);
            }
            else if (HasNext())
            {
                return _nextHandler.Handle(meta);
            }
            throw new NotSupportedException("No suitable handler found for the message");
        }

        public abstract bool IsAccept(TMetadata meta);

        public abstract TMessage Process(TMetadata meta);
    }
}
