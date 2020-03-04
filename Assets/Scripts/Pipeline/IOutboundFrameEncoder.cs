namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public interface IOutboundFrameEncoder
    {
        byte[] Encode(byte[] bytearray);
    }
}