namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public interface IOutboundMessageHandler<TMessage, TMetadata>
    {
        void SetPrev(IOutboundMessageHandler<TMessage, TMetadata> handler);
        IOutboundMessageHandler<TMessage, TMetadata> SetNext(IOutboundMessageHandler<TMessage, TMetadata> outboundHandler);
        IOutboundMessageHandler<TMessage, TMetadata> GetFirst();
        TMessage Handle(TMetadata meta);
        bool IsAccept(TMetadata meta);
        TMessage Process(TMetadata meta);
    }
}