namespace Pipeline
{
    public interface IInboundTemplate<out TMetadata>
    {
        TMetadata[] Translate(byte[] bytearray);
    }
}