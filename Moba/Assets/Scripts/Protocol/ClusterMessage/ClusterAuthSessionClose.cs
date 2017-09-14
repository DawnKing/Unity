// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    //MSGTYPE_DECLARE(MSG_CLUSTER_AUTH_SESSIONCLOSE),
    //认证前端->认证中心，通知有登录SESSION请求关闭
    public sealed class ClusterAuthSessionClose : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLUSTER_AUTH_SESSIONCLOSE;
        public short GetMsgType { get { return MsgType; } }
        public ushort reason;
        public uint region;
        public uint svr_uid;
        public uint session;
        public uint client_cid;// 客户端在目标服务器上的CID
        public uint AcctId;// 账号id
        
        public static void Send(ushort reason, uint region, uint svr_uid, uint session, uint client_cid, uint acctId, object className)
        {
            var packet = new ClusterAuthSessionClose
            {
                reason = reason,
                region = region,
                svr_uid = svr_uid,
                session = session,
                client_cid = client_cid,
                AcctId = acctId
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
            reason = reader.ReadUInt16();
            region = reader.ReadUInt32();
            svr_uid = reader.ReadUInt32();
            session = reader.ReadUInt32();
            client_cid = reader.ReadUInt32();
            AcctId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(reason);
            writer.Write(region);
            writer.Write(svr_uid);
            writer.Write(session);
            writer.Write(client_cid);
            writer.Write(AcctId);
        }
    }
}
