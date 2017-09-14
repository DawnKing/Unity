// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    /// track->activity
    public sealed class RequestGuildMatchSelectedTank : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_GUILD_MATCH_SELECTED_TANK;
        public short GetMsgType { get { return MsgType; } }
        public uint RoomId;
        public string strUuid;
        
        public static void Send(uint roomId, string strUuid, object className)
        {
            var packet = new RequestGuildMatchSelectedTank
            {
                RoomId = roomId,
                strUuid = strUuid
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
            RoomId = reader.ReadUInt32();
            strUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(RoomId);
            writer.Write(strUuid);
        }
    }
}
