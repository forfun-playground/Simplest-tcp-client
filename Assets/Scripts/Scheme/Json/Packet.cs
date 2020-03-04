using System;

namespace ForFun.Playground.SimpleTcpClient.Scheme.Json
{
    public class Packet
    {
        public enum MessageType
        {
            EnterWorldResponse,
            SnapshotResponse,
            TargetPositionRequest
        }

        public MessageType type;
        public String message;
    }
}