// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    public sealed class TeamCache
    {
        public TeamBrief teamBrief;// 战队数据
        public uint Level;// 战队等级
        public uint ExtFlag;// TEAM_EXT_FLAG_BIT
        public string leaderUuid;// 战队队长Uuid
        public string[] memberVec;// 成员列表
        public void ReadFromStream(BinaryReader reader)
        {
            teamBrief = new TeamBrief();
            teamBrief.ReadFromStream(reader);
            Level = reader.ReadUInt32();
            ExtFlag = reader.ReadUInt32();
            leaderUuid = reader.ReadString();
            var length5 = reader.ReadUInt16();
            memberVec = new string[length5];
            for (var i5 = 0; i5 < length5; i5++)
            {
                memberVec[i5] = reader.ReadString();
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            teamBrief.WriteToStream(writer);
            writer.Write(Level);
            writer.Write(ExtFlag);
            writer.Write(leaderUuid);
            ushort count5 = (ushort)(memberVec == null ? 0 : memberVec.Length);
            writer.Write(count5);
            for(var i5 = 0; i5 < count5; i5++)
            {
                writer.Write(memberVec[i5]);
            }
        }
    }
}