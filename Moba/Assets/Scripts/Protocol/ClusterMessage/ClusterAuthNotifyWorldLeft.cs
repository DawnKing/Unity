// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    //MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_WLEFT),
    //认证中心->，通知有角色离开游戏世界
    public sealed class ClusterAuthNotifyWorldLeft : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLUSTER_AUTH_NOTIFY_WLEFT;
        public short GetMsgType { get { return MsgType; } }
        public uint region_id;//区服的ID
        public uint svr_uid;//通知事件源所在的服务器UID
        public uint session;//SessionKey
        public uint account_id;//角色的帐号id
        public string char_name;//角色名称
        public string login;//登录名
        
        public static void Send(uint region_id, uint svr_uid, uint session, uint account_id, string char_name, string login, object className)
        {
            var packet = new ClusterAuthNotifyWorldLeft
            {
                region_id = region_id,
                svr_uid = svr_uid,
                session = session,
                account_id = account_id,
                char_name = char_name,
                login = login
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
            region_id = reader.ReadUInt32();
            svr_uid = reader.ReadUInt32();
            session = reader.ReadUInt32();
            account_id = reader.ReadUInt32();
            char_name = reader.ReadString();
            login = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(region_id);
            writer.Write(svr_uid);
            writer.Write(session);
            writer.Write(account_id);
            writer.Write(char_name);
            writer.Write(login);
        }
    }
}
