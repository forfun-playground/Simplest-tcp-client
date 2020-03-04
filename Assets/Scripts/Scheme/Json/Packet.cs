using System;

namespace forfun.sandbox.uwns.util.pack.json
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