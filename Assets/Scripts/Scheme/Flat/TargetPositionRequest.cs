// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace forfun.sandbox.uwns.util.pack.flat
{

using global::System;
using global::FlatBuffers;

public struct TargetPositionRequest : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static TargetPositionRequest GetRootAsTargetPositionRequest(ByteBuffer _bb) { return GetRootAsTargetPositionRequest(_bb, new TargetPositionRequest()); }
  public static TargetPositionRequest GetRootAsTargetPositionRequest(ByteBuffer _bb, TargetPositionRequest obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p.bb_pos = _i; __p.bb = _bb; }
  public TargetPositionRequest __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public Vector? Position { get { int o = __p.__offset(4); return o != 0 ? (Vector?)(new Vector()).__assign(o + __p.bb_pos, __p.bb) : null; } }

  public static void StartTargetPositionRequest(FlatBufferBuilder builder) { builder.StartObject(1); }
  public static void AddPosition(FlatBufferBuilder builder, Offset<Vector> positionOffset) { builder.AddStruct(0, positionOffset.Value, 0); }
  public static Offset<TargetPositionRequest> EndTargetPositionRequest(FlatBufferBuilder builder) {
    int o = builder.EndObject();
    return new Offset<TargetPositionRequest>(o);
  }
};


}
