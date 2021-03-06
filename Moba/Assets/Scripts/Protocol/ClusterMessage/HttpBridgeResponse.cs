// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ClusterMessage
{
    /// MSGTYPE_DECLARE(MSG_HTTP_BRIDGE_RESPONSE),				// 桥接HTTP服务器响应
    public sealed class HttpBridgeResponse : IProtocol
    {
        public const short MsgType = MessageType.MSG_HTTP_BRIDGE_RESPONSE;
        public short GetMsgType { get { return MsgType; } }
        public uint reqcmd;// HTTP请求的命令类型
        public int reqtype;// HTTP请求的类型，参见HTTP_REQ_TYPE枚举
        public uint receipt;// 回调的HTTP请求ID
        public int state;// 对应线程操作的返回码
        public uint resCode;// 对应HTTP的返回代码
        public double resTime;// 对应HTTP的请求处理时间
        public double resDns;// 对应HTTP的域名解析时间
        public double resConn;// 对应HTTP的连接时间
        public string response;// 请求返回内容
        
        public static void Send(uint reqcmd, int reqtype, uint receipt, int state, uint resCode, double resTime, double resDns, double resConn, string response, object className)
        {
            var packet = new HttpBridgeResponse
            {
                reqcmd = reqcmd,
                reqtype = reqtype,
                receipt = receipt,
                state = state,
                resCode = resCode,
                resTime = resTime,
                resDns = resDns,
                resConn = resConn,
                response = response
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
            reqcmd = reader.ReadUInt32();
            reqtype = reader.ReadInt32();
            receipt = reader.ReadUInt32();
            state = reader.ReadInt32();
            resCode = reader.ReadUInt32();
            resTime = reader.ReadSingle();
            resDns = reader.ReadSingle();
            resConn = reader.ReadSingle();
            response = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(reqcmd);
            writer.Write(reqtype);
            writer.Write(receipt);
            writer.Write(state);
            writer.Write(resCode);
            writer.Write(resTime);
            writer.Write(resDns);
            writer.Write(resConn);
            writer.Write(response);
        }
    }
}
