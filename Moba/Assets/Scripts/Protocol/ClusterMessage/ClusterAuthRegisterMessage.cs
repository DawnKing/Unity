// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    // ----------------------------------------------------------------------
    ///	@file			protocol/ClusterMessage.h
    ///	@brief
    ///	@author			Bob Lee (bob@onwind.cn)
    ///	@copyright		Sixcube Information Technology Co,. Ltd. (2012)
    ///	@date			2005-8-18 21:10:55
    // ----------------------------------------------------------------------
    /// @addtogroup dt_ClusterMessage
    /// @{
    /// 认证服务器，注册服务
    /// 也用来通知游戏服务器，网关服务器OK
    /// MSGTYPE_DECLARE(MSG_CLUSTER_AUTHREGISTER),
    public sealed class ClusterAuthRegisterMessage : IProtocol
    {
        public const short MsgType = MessageType.MSG_CLUSTER_AUTH_REGISTER;
        public short GetMsgType { get { return MsgType; } }
        public uint nodetype;// 参见上面的枚举NODE_TYPE
        public uint events;// 参见上面的枚举AUTH_EVENT
        public uint region;// 区服的唯一标识
        public uint svr_uid;// 网关服务器的唯一编号
        
        public static void Send(uint nodetype, uint events, uint region, uint svr_uid, object className)
        {
            var packet = new ClusterAuthRegisterMessage
            {
                nodetype = nodetype,
                events = events,
                region = region,
                svr_uid = svr_uid
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
            nodetype = reader.ReadUInt32();
            events = reader.ReadUInt32();
            region = reader.ReadUInt32();
            svr_uid = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nodetype);
            writer.Write(events);
            writer.Write(region);
            writer.Write(svr_uid);
        }
    }
}
