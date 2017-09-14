// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    /// MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_NOTIFY_SREQUEST),
    /// 认证中心->，通知有登录请求
    public sealed class ClusterAuthNotifySessionRequest : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLUSTER_AUTH_NOTIFY_SREQUEST;
        public short GetMsgType { get { return MsgType; } }
        public byte microclient;// 是否微端：1-是；0-不是; 2-腾讯平台
        public uint act_oid;// 帐号OID
        public uint session;// SessionID
        public string login;// 登录名
        public string token;// 市场活动代码
        public string serialKey;// 密码(openkey)
        public string channel;// 用户渠道来源
        public string passport;// 用户通行证(多玩用)
        
        public static void Send(byte microclient, uint act_oid, uint session, string login, string token, string serialKey, string channel, string passport, object className)
        {
            var packet = new ClusterAuthNotifySessionRequest
            {
                microclient = microclient,
                act_oid = act_oid,
                session = session,
                login = login,
                token = token,
                serialKey = serialKey,
                channel = channel,
                passport = passport
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
            microclient = reader.ReadByte();
            act_oid = reader.ReadUInt32();
            session = reader.ReadUInt32();
            login = reader.ReadString();
            token = reader.ReadString();
            serialKey = reader.ReadString();
            channel = reader.ReadString();
            passport = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(microclient);
            writer.Write(act_oid);
            writer.Write(session);
            writer.Write(login);
            writer.Write(token);
            writer.Write(serialKey);
            writer.Write(channel);
            writer.Write(passport);
        }
    }
}