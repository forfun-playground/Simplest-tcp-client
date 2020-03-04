namespace Pipeline
{
    public interface IInboundFrameDecoder
    {
        void Decode(byte[] bytearray);
        bool HasFrame();
        byte[] GetFrame();
    }
}