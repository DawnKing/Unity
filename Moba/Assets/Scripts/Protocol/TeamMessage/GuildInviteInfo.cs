// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    // 推荐人信息
    public sealed class GuildInviteInfo
    {
        public uint nAcctId;// 帐号id
        public string szInviteName;// 推荐人名字
        public void ReadFromStream(BinaryReader reader)
        {
            nAcctId = reader.ReadUInt32();
            szInviteName = reader.ReadString();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(nAcctId);
            writer.Write(szInviteName);
        }
    }
}
