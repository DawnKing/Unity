// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 未开始
    // 红方获胜
    // 蓝方获胜
    // 平局
    //
    public sealed class GuildMatchTeamContest
    {
        public GuildMatchTeamBrief teamRed;
        public GuildMatchTeamBrief teamBlue;
        public uint Result;// enum GUILD_MATCH_BATTLE_RESULT
        public void ReadFromStream(BinaryReader reader)
        {
            teamRed = new GuildMatchTeamBrief();
            teamRed.ReadFromStream(reader);
            teamBlue = new GuildMatchTeamBrief();
            teamBlue.ReadFromStream(reader);
            Result = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            teamRed.WriteToStream(writer);
            teamBlue.WriteToStream(writer);
            writer.Write(Result);
        }
    }
}