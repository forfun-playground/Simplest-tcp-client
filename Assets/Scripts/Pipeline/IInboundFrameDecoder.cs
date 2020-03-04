namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public interface IInboundFrameDecoder
    {
        void Decode(byte[] bytearray);
        bool HasFrame();
        byte[] GetFrame();
    }
}