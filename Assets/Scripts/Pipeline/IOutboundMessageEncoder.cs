namespace ForFun.Playground.SimpleTcpClient.Pipeline
{
    public interface IOutboundMessageEncoder<in TMessage>
    {
        byte[] Encode(TMessage message);
    }
}