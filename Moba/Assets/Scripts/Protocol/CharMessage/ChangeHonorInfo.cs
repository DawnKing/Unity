// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.CharMessage
{
    /// gm后台改变玩家的荣誉
    public sealed class ChangeHonorInfo
    {
        public uint[] giveVec;
        public uint[] lostVec;
        public void ReadFromStream(BinaryReader reader)
        {
            var length1 = reader.ReadUInt16();
            giveVec = new uint[length1];
            for (var i1 = 0; i1 < length1; i1++)
            {
                giveVec[i1] = reader.ReadUInt32();
            }
            var length2 = reader.ReadUInt16();
            lostVec = new uint[length2];
            for (var i2 = 0; i2 < length2; i2++)
            {
                lostVec[i2] = reader.ReadUInt32();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            ushort count1 = (ushort)(giveVec == null ? 0 : giveVec.Length);
            writer.Write(count1);
            for(var i1 = 0; i1 < count1; i1++)
            {
                writer.Write(giveVec[i1]);
            }
            ushort count2 = (ushort)(lostVec == null ? 0 : lostVec.Length);
            writer.Write(count2);
            for(var i2 = 0; i2 < count2; i2++)
            {
                writer.Write(lostVec[i2]);
            }
        }
    }
}