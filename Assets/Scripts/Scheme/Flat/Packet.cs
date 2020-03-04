// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace forfun.sandbox.uwns.util.pack.flat
{

using global::System;
using global::FlatBuffers;

public struct Packet : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static Packet GetRootAsPacket(ByteBuffer _bb) { return GetRootAsPacket(_bb, new Packet()); }
  public static Packet GetRootAsPacket(ByteBuffer _bb, Packet obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public Packet __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Message DataType { get { int o = __p.__offset(4); return o != 0 ? (Message)__p.bb.Get(o + __p.bb_pos) : Message.NONE; } }
  public TTable? Data<TTable>() where TTable : struct, IFlatbufferObject { int o = __p.__offset(6); return o != 0 ? (TTable?)__p.__union<TTable>(o) : null; }

  public static Offset<Packet> CreatePacket(FlatBufferBuilder builder,
      Message data_type = Message.NONE,
      int dataOffset = 0) {
    builder.StartObject(2);
    Packet.AddData(builder, dataOffset);
    Packet.AddDataType(builder, data_type);
    return Packet.EndPacket(builder);
  }

  public static void StartPacket(FlatBufferBuilder builder) { builder.StartObject(2); }
  public static void AddDataType(FlatBufferBuilder builder, Message dataType) { builder.AddByte(0, (byte)dataType, 0); }
  public static void AddData(FlatBufferBuilder builder, int dataOffset) { builder.AddOffset(1, dataOffset, 0); }
  public static Offset<Packet> EndPacket(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<Packet>(o);
  }
  public static void FinishPacketBuffer(FlatBufferBuilder builder, Offset<Packet> offset) { builder.Finish(offset.Value); }
  public static void FinishSizePrefixedPacketBuffer(FlatBufferBuilder builder, Offset<Packet> offset) { builder.FinishSizePrefixed(offset.Value); }
};


}
