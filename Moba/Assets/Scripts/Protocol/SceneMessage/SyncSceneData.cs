// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.TankMessage;
namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_SYNC_SCENE_DATA),
    // 战场数据同步
    public sealed class SyncSceneData : IProtocol
    {
        public const short MsgType = MessageType.MSG_SYNC_SCENE_DATA;
        public short GetMsgType { get { return MsgType; } }
        public MoveInfo[] moveVec;// 移动同步
        public NotifyFire[] fireVec;// 开火
        public NotifyUseSkill[] skillVec;// 使用技能
        public ObjectHp[] hpVec;// 更新血条
        public AINpcDead[] deadVec;// AINpc死亡表现
        public ObjectMp[] mpVec;// 更新能量条
        public ulong[] blowUpVec;// 爆炸的炮弹列表
        public ulong[] delVec;// 需要删除的对象列表
        public ulong[] overVec;// 存在时间到消失列表
        
        public static void Send(MoveInfo[] moveVec, NotifyFire[] fireVec, NotifyUseSkill[] skillVec, ObjectHp[] hpVec, AINpcDead[] deadVec, ObjectMp[] mpVec, ulong[] blowUpVec, ulong[] delVec, ulong[] overVec, object className)
        {
            var packet = new SyncSceneData
            {
                moveVec = moveVec,
                fireVec = fireVec,
                skillVec = skillVec,
                hpVec = hpVec,
                deadVec = deadVec,
                mpVec = mpVec,
                blowUpVec = blowUpVec,
                delVec = delVec,
                overVec = overVec
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
            moveVec = new MoveInfo[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                moveVec[i1] = new MoveInfo();
                moveVec[i1].ReadFromStream(reader);
            }
            var length2 = reader.ReadUInt16();
            fireVec = new NotifyFire[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                fireVec[i2] = new NotifyFire();
                fireVec[i2].ReadFromStream(reader);
            }
            var length3 = reader.ReadUInt16();
            skillVec = new NotifyUseSkill[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                skillVec[i3] = new NotifyUseSkill();
                skillVec[i3].ReadFromStream(reader);
            }
            var length4 = reader.ReadUInt16();
            hpVec = new ObjectHp[length4];
            for (var i4 = 0; i4 < length4; i4++)
            {
                hpVec[i4] = new ObjectHp();
                hpVec[i4].ReadFromStream(reader);
            }
            var length5 = reader.ReadUInt16();
            deadVec = new AINpcDead[length5];
            for (var i5 = 0; i5 < length5; i5++)
            {
                deadVec[i5] = new AINpcDead();
                deadVec[i5].ReadFromStream(reader);
            }
            var length6 = reader.ReadUInt16();
            mpVec = new ObjectMp[length6];
            for (var i6 = 0; i6 < length6; i6++)
            {
                mpVec[i6] = new ObjectMp();
                mpVec[i6].ReadFromStream(reader);
            }
            var length7 = reader.ReadUInt16();
            blowUpVec = new ulong[length7];
            for (var i7 = 0; i7 < length7; i7++)
            {
                blowUpVec[i7] = reader.ReadUInt64();
            }
            var length8 = reader.ReadUInt16();
            delVec = new ulong[length8];
            for (var i8 = 0; i8 < length8; i8++)
            {
                delVec[i8] = reader.ReadUInt64();
            }
            var length9 = reader.ReadUInt16();
            overVec = new ulong[length9];
            for (var i9 = 0; i9 < length9; i9++)
            {
                overVec[i9] = reader.ReadUInt64();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(moveVec == null ? 0 : moveVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                moveVec[i1].WriteToStream(writer);
            }
            ushort count2 = (ushort)(fireVec == null ? 0 : fireVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                fireVec[i2].WriteToStream(writer);
            }
            ushort count3 = (ushort)(skillVec == null ? 0 : skillVec.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                skillVec[i3].WriteToStream(writer);
            }
            ushort count4 = (ushort)(hpVec == null ? 0 : hpVec.Length);
            writer.Write(count4);
            for(var i4 = 0; i4 < count4; i4++)
            {
                hpVec[i4].WriteToStream(writer);
            }
            ushort count5 = (ushort)(deadVec == null ? 0 : deadVec.Length);
            writer.Write(count5);
            for(var i5 = 0; i5 < count5; i5++)
            {
                deadVec[i5].WriteToStream(writer);
            }
            ushort count6 = (ushort)(mpVec == null ? 0 : mpVec.Length);
            writer.Write(count6);
            for(var i6 = 0; i6 < count6; i6++)
            {
                mpVec[i6].WriteToStream(writer);
            }
            ushort count7 = (ushort)(blowUpVec == null ? 0 : blowUpVec.Length);
            writer.Write(count7);
            for(var i7 = 0; i7 < count7; i7++)
            {
                writer.Write(blowUpVec[i7]);
            }
            ushort count8 = (ushort)(delVec == null ? 0 : delVec.Length);
            writer.Write(count8);
            for(var i8 = 0; i8 < count8; i8++)
            {
                writer.Write(delVec[i8]);
            }
            ushort count9 = (ushort)(overVec == null ? 0 : overVec.Length);
            writer.Write(count9);
            for(var i9 = 0; i9 < count9; i9++)
            {
                writer.Write(overVec[i9]);
            }
        }
    }
}
