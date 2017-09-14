// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    public sealed class NotifyTankSkinChipInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_TANK_SKIN_CHIP_INFO;
        public short GetMsgType { get { return MsgType; } }
        public TankSkinChipInfo[] vecChip;/// 皮肤碎片
        
        public static void Send(TankSkinChipInfo[] vecChip, object className)
        {
            var packet = new NotifyTankSkinChipInfo
            {
                vecChip = vecChip
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
            var length1 = reader.ReadUInt16();
            vecChip = new TankSkinChipInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                vecChip[i1] = new TankSkinChipInfo();
                vecChip[i1].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(vecChip == null ? 0 : vecChip.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                vecChip[i1].WriteToStream(writer);
            }
        }
    }
}