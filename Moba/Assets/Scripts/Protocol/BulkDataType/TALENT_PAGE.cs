// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.BulkDataType
{
    // 天赋页
    public sealed class TALENT_PAGE
    {
        public string strUuid;// 天赋页uuid
        public string strPageName;// 天赋页名字
        public TALENT_GRID[] talentTree;// 天赋树信息
        public uint nCreateTime;// 创建时间
        public void ReadFromStream(BinaryReader reader)
        {
            strUuid = reader.ReadString();
            strPageName = reader.ReadString();
            var length3 = reader.ReadUInt16();
            talentTree = new TALENT_GRID[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                talentTree[i3] = new TALENT_GRID();
                talentTree[i3].ReadFromStream(reader);
            }
            nCreateTime = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(strUuid);
            writer.Write(strPageName);
            ushort count3 = (ushort)(talentTree == null ? 0 : talentTree.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                talentTree[i3].WriteToStream(writer);
            }
            writer.Write(nCreateTime);
        }
    }
}