// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // 通知客户端坦克战场等级
    public sealed class NotifyTankBattleLevel : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TANK_BATTLE_LEVEL;
        public short GetMsgType { get { return MsgType; } }
        public uint objectId;
        public byte Level;
        
        public static void Send(uint objectId, byte level, object className)
        {
            var packet = new NotifyTankBattleLevel
            {
                objectId = objectId,
                Level = level
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
            objectId = reader.ReadUInt32();
            Level = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(objectId);
            writer.Write(Level);
        }
    }
}
