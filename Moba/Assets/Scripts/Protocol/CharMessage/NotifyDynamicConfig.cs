// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    // 通知动态配置信息
    public sealed class NotifyDynamicConfig : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_DYNAMIC_CONFIG;
        public short GetMsgType { get { return MsgType; } }
        public uint[] hideTankVec;// 禁用坦克列表
        public int escapeCoin;// 逃跑扣除银币数(限 匹配赛ROOM_PVP、战队排位赛ROOM_TEAM_MATCH)
        public uint[] closedActVec;// 关闭的活动列表
        public uint[] banActiveGuildSkillVec;// 禁用主动军团技能的房间类型
        public uint[] banPassiveGuildSkillVec;// 禁用被动军团技能的房间类型
        public ClientOpAct[] closeOpAct;// 关闭的客户端运营活动列表
        public int diffZoneTime;// 服务端和标准时间差
        public float presentPointRate;// 赠送点数比率（小于0表示关闭赠送扣除点数功能）
        
        public static void Send(uint[] hideTankVec, int escapeCoin, uint[] closedActVec, uint[] banActiveGuildSkillVec, uint[] banPassiveGuildSkillVec, ClientOpAct[] closeOpAct, int diffZoneTime, float presentPointRate, object className)
        {
            var packet = new NotifyDynamicConfig
            {
                hideTankVec = hideTankVec,
                escapeCoin = escapeCoin,
                closedActVec = closedActVec,
                banActiveGuildSkillVec = banActiveGuildSkillVec,
                banPassiveGuildSkillVec = banPassiveGuildSkillVec,
                closeOpAct = closeOpAct,
                diffZoneTime = diffZoneTime,
                presentPointRate = presentPointRate
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
            hideTankVec = new uint[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                hideTankVec[i1] = reader.ReadUInt32();
            }
            escapeCoin = reader.ReadInt32();
            var length3 = reader.ReadUInt16();
            closedActVec = new uint[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                closedActVec[i3] = reader.ReadUInt32();
            }
            var length4 = reader.ReadUInt16();
            banActiveGuildSkillVec = new uint[length4];
            for (var i4 = 0; i4 < length4; i4++)
            {
                banActiveGuildSkillVec[i4] = reader.ReadUInt32();
            }
            var length5 = reader.ReadUInt16();
            banPassiveGuildSkillVec = new uint[length5];
            for (var i5 = 0; i5 < length5; i5++)
            {
                banPassiveGuildSkillVec[i5] = reader.ReadUInt32();
            }
            var length6 = reader.ReadUInt16();
            closeOpAct = new ClientOpAct[length6];
            for (var i6 = 0; i6 < length6; i6++)
            {
                closeOpAct[i6] = new ClientOpAct();
                closeOpAct[i6].ReadFromStream(reader);
            }
            diffZoneTime = reader.ReadInt32();
            presentPointRate = reader.ReadSingle();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(hideTankVec == null ? 0 : hideTankVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(hideTankVec[i1]);
            }
            writer.Write(escapeCoin);
            ushort count3 = (ushort)(closedActVec == null ? 0 : closedActVec.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                writer.Write(closedActVec[i3]);
            }
            ushort count4 = (ushort)(banActiveGuildSkillVec == null ? 0 : banActiveGuildSkillVec.Length);
            writer.Write(count4);
            for(var i4 = 0; i4 < count4; i4++)
            {
                writer.Write(banActiveGuildSkillVec[i4]);
            }
            ushort count5 = (ushort)(banPassiveGuildSkillVec == null ? 0 : banPassiveGuildSkillVec.Length);
            writer.Write(count5);
            for(var i5 = 0; i5 < count5; i5++)
            {
                writer.Write(banPassiveGuildSkillVec[i5]);
            }
            ushort count6 = (ushort)(closeOpAct == null ? 0 : closeOpAct.Length);
            writer.Write(count6);
            for(var i6 = 0; i6 < count6; i6++)
            {
                closeOpAct[i6].WriteToStream(writer);
            }
            writer.Write(diffZoneTime);
            writer.Write(presentPointRate);
        }
    }
}
