namespace Pipeline
{
    public interface IOutboundMessageEncoder<in TMessage>
    {
        byte[] Encode(TMessage message);
    }
}