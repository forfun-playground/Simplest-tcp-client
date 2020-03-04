using System;

namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public abstract class InboundMessageHandlerBase<TMessage, TMetadata> : IInboundMessageHandler<TMessage, TMetadata>
    {
        private IInboundMessageHandler<TMessage, TMetadata> _prevHandler;
        private IInboundMessageHandler<TMessage, TMetadata> _nextHandler;

        public void SetPrev(IInboundMessageHandler<TMessage, TMetadata> handler)
        {
            this._prevHandler = handler;
        }

        public IInboundMessageHandler<TMessage, TMetadata> SetNext(IInboundMessageHandler<TMessage, TMetadata> handler)
        {
            handler.SetPrev(this);
            _nextHandler = handler;
            return handler;
        }

        public IInboundMessageHandler<TMessage, TMetadata> GetFirst()
        {
            return _prevHandler != null ? _prevHandler.GetFirst() : this;
        }

        private bool HasNext() { return _nextHandler != null; }

        public virtual TMetadata Handle(TMessage msg)
        {
            if (IsAccept(msg))
            {
                return Process(msg);
            }
            else if (HasNext())
            {
                return _nextHandler.Handle(msg);
            }
            throw new NotSupportedException("No suitable handler found for the message");
        }

        public abstract bool IsAccept(TMessage msg);

        public abstract TMetadata Process(TMessage msg);
    }
}