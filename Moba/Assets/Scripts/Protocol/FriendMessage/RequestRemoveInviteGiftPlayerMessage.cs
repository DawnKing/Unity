// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    /// 请求解除邀请好礼玩家关系
    public sealed class RequestRemoveInviteGiftPlayerMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_REMOVE_INVITE_GIFT_PLAYER;
        public short GetMsgType { get { return MsgType; } }
        public string strUuid;// 目标的uuid
        
        public static void Send(string strUuid, object className)
        {
            var packet = new RequestRemoveInviteGiftPlayerMessage
            {
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
            strUuid = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strUuid);
        }
    }
}
