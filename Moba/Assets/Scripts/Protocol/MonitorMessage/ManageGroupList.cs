// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MonitorMessage
{
    /// MSGTYPE_DECLARE(MSG_MANAGE_GROUPLIST),
    /// 管理消息，返回进程组列表
    public sealed class ManageGroupList : IProtocol
    {
        public const short MsgType = MessageType.MSG_MANAGE_GROUPLIST;
        public short GetMsgType { get { return MsgType; } }
        public string node;// 节点ID，通常应该是外网IP
        public ProcGroup[] groups;// 返回进程组信息
        
        public static void Send(string node, ProcGroup[] groups, object className)
        {
            var packet = new ManageGroupList
            {
                node = node,
                groups = groups
            };
            NetMessage.Send(packet.BuildPacket(), className);
        }
        
        public byte[] BuildPacket()
        {
            var buffer = ProtocolBuffer.Writer;
            buffer.Write(MsgType);
            buffer.Write(ProtocolBuffer.Zero);
            WriteToStream(buffer);
            return ProtocolBuffer.CacheStream.ToArray();
        }
        
        public void ReadFromStream(BinaryReader reader)
        {
            node = reader.ReadString();
            var length2 = reader.ReadUInt16();
            groups = new ProcGroup[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                groups[i2] = new ProcGroup();
                groups[i2].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(node);
            ushort count2 = (ushort)(groups == null ? 0 : groups.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                groups[i2].WriteToStream(writer);
            }
        }
    }
}
