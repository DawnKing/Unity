// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.TeamMessage
{
    public sealed class ChallengeInfo
    {
        public TeamBrief teamBrief;
        public uint State;// CHALLENGE_LIST_STATE
        public int Count;// 剩余被挑战次数
        public int Place;// 挑战列表的排名
        public uint Scores;// 当前积分
        public uint Contest;// 分配到的对阵ID
        public uint Turn;// 被挑战的轮次
        public uint Start;// 轮次开始的时间
        public uint Cluster;// 所在区服
        public void ReadFromStream(BinaryReader reader)
        {
            teamBrief = new TeamBrief();
            teamBrief.ReadFromStream(reader);
            State = reader.ReadUInt32();
            Count = reader.ReadInt32();
            Place = reader.ReadInt32();
            Scores = reader.ReadUInt32();
            Contest = reader.ReadUInt32();
            Turn = reader.ReadUInt32();
            Start = reader.ReadUInt32();
            Cluster = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            teamBrief.WriteToStream(writer);
            writer.Write(State);
            writer.Write(Count);
            writer.Write(Place);
            writer.Write(Scores);
            writer.Write(Contest);
            writer.Write(Turn);
            writer.Write(Start);
            writer.Write(Cluster);
        }
    }
}
