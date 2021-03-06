// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    /// 回复邀请好礼邀请
    public sealed class ResponseInviteGiftPlayerInviteMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_RESPONSE_INVITE_GIFT_PLAYER_INVITE;
        public short GetMsgType { get { return MsgType; } }
        public const int RT_CONFIRM = 1;//确认
        public const int RT_CANCEL = 2;//取消
        public string strUuid;// 邀请者的uuid
        public uint responseType;// 回复类型
        
        public static void Send(string strUuid, uint responseType, object className)
        {
            var packet = new ResponseInviteGiftPlayerInviteMessage
            {
                strUuid = strUuid,
                responseType = responseType
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
            responseType = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strUuid);
            writer.Write(responseType);
        }
    }
}
