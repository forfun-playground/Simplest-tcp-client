namespace Pipeline
{
    public interface IOutboundTemplate<in TMetadata>
    {
        byte[] Translate(TMetadata metadata);
    }
}