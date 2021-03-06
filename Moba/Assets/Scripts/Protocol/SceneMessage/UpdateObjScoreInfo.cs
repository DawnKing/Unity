// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.SceneMessage
{
    /// 更新某辆坦克的分数信息
    public sealed class UpdateObjScoreInfo : IProtocol
    {
        public const short MsgType = MessageType.MSG_UPDATE_TANK_SCORE;
        public short GetMsgType { get { return MsgType; } }
        public int reaon;// 参见SCORE_TYPE枚举
        public OneObjScore values;// 坦克_ID + 所得分数
        public ulong target;// 被击杀的对象ID
        
        public static void Send(int reaon, OneObjScore values, ulong target, object className)
        {
            var packet = new UpdateObjScoreInfo
            {
                reaon = reaon,
                values = values,
                target = target
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
            reaon = reader.ReadInt32();
            values = new OneObjScore();
            values.ReadFromStream(reader);
            target = reader.ReadUInt64();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(reaon);
            values.WriteToStream(writer);
            writer.Write(target);
        }
    }
}
