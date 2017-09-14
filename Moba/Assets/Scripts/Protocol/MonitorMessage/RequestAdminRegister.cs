// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.MonitorMessage
{
    /// 服务器注册到监控后端
    /// MSGTYPE_DECLARE(MSG_ADMIN_REGISTER),
    public sealed class RequestAdminRegister : IProtocol
    {
        public const short MsgType = MessageType.MSG_ADMIN_REGISTER;
        public short GetMsgType { get { return MsgType; } }
        public int serverType;
        public int serverUid;
        public uint serverPort;
        public int processId;
        public string serverName;
        public string command;
        public string loadmaps;
        
        public static void Send(int serverType, int serverUid, uint serverPort, int processId, string serverName, string command, string loadmaps, object className)
        {
            var packet = new RequestAdminRegister
            {
                serverType = serverType,
                serverUid = serverUid,
                serverPort = serverPort,
                processId = processId,
                serverName = serverName,
                command = command,
                loadmaps = loadmaps
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
            serverType = reader.ReadInt32();
            serverUid = reader.ReadInt32();
            serverPort = reader.ReadUInt32();
            processId = reader.ReadInt32();
            serverName = reader.ReadString();
            command = reader.ReadString();
            loadmaps = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(serverType);
            writer.Write(serverUid);
            writer.Write(serverPort);
            writer.Write(processId);
            writer.Write(serverName);
            writer.Write(command);
            writer.Write(loadmaps);
        }
    }
}
