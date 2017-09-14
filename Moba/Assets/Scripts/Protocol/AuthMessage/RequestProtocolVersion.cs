// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    // ----------------------------------------------------------------------
    ///	@file			protocol/AuthMessage.h
    ///	@brief			认证相关协议定义
    ///	@author			侯明园
    ///	@copyright		Sixcube Information Technology Co,. Ltd. (2012)
    ///	@date			2004-12-22 15:10:17
    // ----------------------------------------------------------------------
    /// @addtogroup dt_AuthProtocol
    /// @{
    /**
     * 请求验证协议版本.
     * 
     * MSG_AUTH_REQUEST_AUTH_LOGIN
     */
    public sealed class RequestProtocolVersion : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_REQUEST_PROTOCOL_VERSION;
        public short GetMsgType { get { return MsgType; } }
        public uint auth_ver;// 认证协议版本
        public uint gate_ver;// 网关协议版本
        public uint mixAuth;// 是否是混服认证方式。0，默认认证方式；1，混服认证方式
        public string client_ver;// 客户端版本
        
        public static void Send(uint auth_ver, uint gate_ver, uint mixAuth, string client_ver, object className)
        {
            var packet = new RequestProtocolVersion
            {
                auth_ver = auth_ver,
                gate_ver = gate_ver,
                mixAuth = mixAuth,
                client_ver = client_ver
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
            auth_ver = reader.ReadUInt32();
            gate_ver = reader.ReadUInt32();
            mixAuth = reader.ReadUInt32();
            client_ver = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(auth_ver);
            writer.Write(gate_ver);
            writer.Write(mixAuth);
            writer.Write(client_ver);
        }
    }
}