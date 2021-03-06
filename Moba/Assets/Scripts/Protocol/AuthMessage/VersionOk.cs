// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.AuthMessage
{
    /**
     * 版本验证成功 
     */
    public sealed class VersionOk : IProtocol
    {
        public const short MsgType = MessageType.MSG_AUTH_VESION_OK;
        public short GetMsgType { get { return MsgType; } }
        public uint gameVer;//游戏主程序版本
        public uint dataVer;//数据材质版本
        
        public static void Send(uint gameVer, uint dataVer, object className)
        {
            var packet = new VersionOk
            {
                gameVer = gameVer,
                dataVer = dataVer
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
            gameVer = reader.ReadUInt32();
            dataVer = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(gameVer);
            writer.Write(dataVer);
        }
    }
}
