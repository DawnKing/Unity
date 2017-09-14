// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TankMessage
{
    // MSGTYPE_DECLARE(MSG_NOTIFY_USE_SKILL),
    // 通知使用技能
    public sealed class NotifyUseSkill
    {
        public ulong CasterId;// 施放者id
        public ulong TargetId;// 目标id
        public uint SkillId;// 使用的技能
        public short StartX;// 技能起始点x 坐标
        public short StartY;// 技能起始点y 坐标
        public short x;// 技能目标点x 坐标
        public short y;// 技能目标点y 坐标
        public byte isReady;// 1：代表播放释放动画 0:表示技能生效
        public byte Count;// 该技能释放的次数
        public void ReadFromStream(BinaryReader reader)
        {
            CasterId = reader.ReadUInt64();
            TargetId = reader.ReadUInt64();
            SkillId = reader.ReadUInt32();
            StartX = reader.ReadInt16();
            StartY = reader.ReadInt16();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            isReady = reader.ReadByte();
            Count = reader.ReadByte();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(CasterId);
            writer.Write(TargetId);
            writer.Write(SkillId);
            writer.Write(StartX);
            writer.Write(StartY);
            writer.Write(x);
            writer.Write(y);
            writer.Write(isReady);
            writer.Write(Count);
        }
    }
}