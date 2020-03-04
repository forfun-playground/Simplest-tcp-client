namespace Pipeline
{
    public interface IOutboundFrameEncoder
    {
        byte[] Encode(byte[] bytearray);
    }
}