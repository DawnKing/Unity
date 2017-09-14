// Generated by the protocol buffer compiler.  DO NOT EDIT!
// source: PlayerMessage.proto
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace GameProtocol {

  /// <summary>Holder for reflection information generated from PlayerMessage.proto</summary>
  public static partial class PlayerMessageReflection {

    #region Descriptor
    /// <summary>File descriptor for PlayerMessage.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static PlayerMessageReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChNQbGF5ZXJNZXNzYWdlLnByb3RvIjQKEE5vdGlmeVNlbGZQbGF5ZXISCgoC",
            "aWQYASABKA0SCQoBWBgCIAEoAhIJCgFaGAMgASgCQg+qAgxHYW1lUHJvdG9j",
            "b2xiBnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::GameProtocol.NotifySelfPlayer), global::GameProtocol.NotifySelfPlayer.Parser, new[]{ "Id", "X", "Z" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class NotifySelfPlayer : pb::IMessage<NotifySelfPlayer> {
    private static readonly pb::MessageParser<NotifySelfPlayer> _parser = new pb::MessageParser<NotifySelfPlayer>(() => new NotifySelfPlayer());
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<NotifySelfPlayer> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::GameProtocol.PlayerMessageReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NotifySelfPlayer() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NotifySelfPlayer(NotifySelfPlayer other) : this() {
      id_ = other.id_;
      x_ = other.x_;
      z_ = other.z_;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public NotifySelfPlayer Clone() {
      return new NotifySelfPlayer(this);
    }

    /// <summary>Field number for the "id" field.</summary>
    public const int IdFieldNumber = 1;
    private uint id_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public uint Id {
      get { return id_; }
      set {
        id_ = value;
      }
    }

    /// <summary>Field number for the "X" field.</summary>
    public const int XFieldNumber = 2;
    private float x_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float X {
      get { return x_; }
      set {
        x_ = value;
      }
    }

    /// <summary>Field number for the "Z" field.</summary>
    public const int ZFieldNumber = 3;
    private float z_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public float Z {
      get { return z_; }
      set {
        z_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as NotifySelfPlayer);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(NotifySelfPlayer other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Id != other.Id) return false;
      if (X != other.X) return false;
      if (Z != other.Z) return false;
      return true;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Id != 0) hash ^= Id.GetHashCode();
      if (X != 0F) hash ^= X.GetHashCode();
      if (Z != 0F) hash ^= Z.GetHashCode();
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Id != 0) {
        output.WriteRawTag(8);
        output.WriteUInt32(Id);
      }
      if (X != 0F) {
        output.WriteRawTag(21);
        output.WriteFloat(X);
      }
      if (Z != 0F) {
        output.WriteRawTag(29);
        output.WriteFloat(Z);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Id != 0) {
        size += 1 + pb::CodedOutputStream.ComputeUInt32Size(Id);
      }
      if (X != 0F) {
        size += 1 + 4;
      }
      if (Z != 0F) {
        size += 1 + 4;
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(NotifySelfPlayer other) {
      if (other == null) {
        return;
      }
      if (other.Id != 0) {
        Id = other.Id;
      }
      if (other.X != 0F) {
        X = other.X;
      }
      if (other.Z != 0F) {
        Z = other.Z;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            input.SkipLastField();
            break;
          case 8: {
            Id = input.ReadUInt32();
            break;
          }
          case 21: {
            X = input.ReadFloat();
            break;
          }
          case 29: {
            Z = input.ReadFloat();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code