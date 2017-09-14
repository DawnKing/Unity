// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    /*
    *   client->server 客户端请求信号机制
    */
    public sealed class RequestSignalInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_SIGNAL_INFO;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;/// 战场Id
        public short DestX;/// 坐标
        public short DestY;
        public byte SignalType;/// 信号类型
        
        public static void Send(uint sceneId, short destX, short destY, byte signalType, object className)
        {
            var packet = new RequestSignalInfo
            {
                SceneId = sceneId,
                DestX = destX,
                DestY = destY,
                SignalType = signalType
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
            SceneId = reader.ReadUInt32();
            DestX = reader.ReadInt16();
            DestY = reader.ReadInt16();
            SignalType = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(DestX);
            writer.Write(DestY);
            writer.Write(SignalType);
        }
    }
}