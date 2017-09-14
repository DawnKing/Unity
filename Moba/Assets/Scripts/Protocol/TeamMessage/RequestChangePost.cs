// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_CHANGE_POST),
    // 请求更换队长
    public sealed class RequestChangePost : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_CHANGE_POST;
        public short GetMsgType { get { return MsgType; } }
        public string targetUuid;// 目标Uuid
        public int Post;// enum TEAM_POST_TYPE
        public uint TeamId;// 目标的战队id
        
        public static void Send(string targetUuid, int post, uint teamId, object className)
        {
            var packet = new RequestChangePost
            {
                targetUuid = targetUuid,
                Post = post,
                TeamId = teamId
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
            targetUuid = reader.ReadString();
            Post = reader.ReadInt32();
            TeamId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(targetUuid);
            writer.Write(Post);
            writer.Write(TeamId);
        }
    }
}
