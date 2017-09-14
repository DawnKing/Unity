// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.SceneMessage
{
    // 请求惩罚逃跑玩家
    public sealed class RequestPunishEscape : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_PUNISH_ESCAPE;
        public short GetMsgType { get { return MsgType; } }
        public uint CharOid;// 角色OID
        public int punishElo;// 扣除的ELO
        public int punishType;// 扣除原因
        
        public static void Send(uint charOid, int punishElo, int punishType, object className)
        {
            var packet = new RequestPunishEscape
            {
                CharOid = charOid,
                punishElo = punishElo,
                punishType = punishType
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
            CharOid = reader.ReadUInt32();
            punishElo = reader.ReadInt32();
            punishType = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CharOid);
            writer.Write(punishElo);
            writer.Write(punishType);
        }
    }
}
