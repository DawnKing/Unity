// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    public sealed class GuildMatchTeamBrief
    {
        public string strName;
        public uint AvatarId;
        public void ReadFromStream(BinaryReader reader)
        {
            strName = reader.ReadString();
            AvatarId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strName);
            writer.Write(AvatarId);
        }
    }
}
