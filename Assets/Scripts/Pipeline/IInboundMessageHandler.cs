namespace Pipeline
{
    public interface IInboundMessageHandler<TMessage, TMetadata>
    {
        void SetPrev(IInboundMessageHandler<TMessage, TMetadata> handler);
        IInboundMessageHandler<TMessage, TMetadata> SetNext(IInboundMessageHandler<TMessage, TMetadata> handler);
        IInboundMessageHandler<TMessage, TMetadata> GetFirst();
        TMetadata Handle(TMessage msg);
        bool IsAccept(TMessage msg);
        TMetadata Process(TMessage msg);
    }
}