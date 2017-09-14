// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 战场对象实例数据
    public sealed class ObjInfo
    {
        public ulong objId;// 对象实例id
        public uint tplId;// npc模板id
        public short x;// x 坐标
        public short y;// y 坐标
        public int hp;// 当前血量
        public byte Camp;// 阵营
        public int maxHp;// 最大血量值
        public ulong ownerId;// 拥有者实例id
        public BuffInfo[] buffVec;// buff信息
        public void ReadFromStream(BinaryReader reader)
        {
            objId = reader.ReadUInt64();
            tplId = reader.ReadUInt32();
            x = reader.ReadInt16();
            y = reader.ReadInt16();
            hp = reader.ReadInt32();
            Camp = reader.ReadByte();
            maxHp = reader.ReadInt32();
            ownerId = reader.ReadUInt64();
            var length9 = reader.ReadUInt16();
            buffVec = new BuffInfo[length9];
            for (var i9 = 0; i9 < length9; i9++)
            {
                buffVec[i9] = new BuffInfo();
                buffVec[i9].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(objId);
            writer.Write(tplId);
            writer.Write(x);
            writer.Write(y);
            writer.Write(hp);
            writer.Write(Camp);
            writer.Write(maxHp);
            writer.Write(ownerId);
            ushort count9 = (ushort)(buffVec == null ? 0 : buffVec.Length);
            writer.Write(count9);
            for(var i9 = 0; i9 < count9; i9++)
            {
                buffVec[i9].WriteToStream(writer);
            }
        }
    }
}