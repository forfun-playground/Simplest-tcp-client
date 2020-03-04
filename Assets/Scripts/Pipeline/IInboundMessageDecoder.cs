namespace Pipeline
{
    public interface IInboundMessageDecoder<out TMessage>
    {
        TMessage Decode(byte[] bytearray);
    }
}