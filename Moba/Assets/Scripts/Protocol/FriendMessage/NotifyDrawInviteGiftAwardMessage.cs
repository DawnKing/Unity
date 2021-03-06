// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    //通知领取邀请好礼奖励
    public sealed class NotifyDrawInviteGiftAwardMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_DRAW_INVITE_GIFT_AWARD;
        public short GetMsgType { get { return MsgType; } }
        public uint awardItemId;// 奖励ID
        public string strUuid;// 目标的uuid
        
        public static void Send(uint awardItemId, string strUuid, object className)
        {
            var packet = new NotifyDrawInviteGiftAwardMessage
            {
                awardItemId = awardItemId,
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
            awardItemId = reader.ReadUInt32();
            strUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(awardItemId);
            writer.Write(strUuid);
        }
    }
}
