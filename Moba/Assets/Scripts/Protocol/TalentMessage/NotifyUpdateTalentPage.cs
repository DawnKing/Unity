// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.TalentMessage
{
    // 通知更新天赋页
    public sealed class NotifyUpdateTalentPage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_UPDATE_TALENT_PAGE;
        public short GetMsgType { get { return MsgType; } }
        public uint opType;// 天赋操作类型
        public TALENT_PAGE talentPage;// 天赋页信息
        
        public static void Send(uint opType, TALENT_PAGE talentPage, object className)
        {
            var packet = new NotifyUpdateTalentPage
            {
                opType = opType,
                talentPage = talentPage
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
            opType = reader.ReadUInt32();
            talentPage = new TALENT_PAGE();
            talentPage.ReadFromStream(reader);
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(opType);
            talentPage.WriteToStream(writer);
        }
    }
}
