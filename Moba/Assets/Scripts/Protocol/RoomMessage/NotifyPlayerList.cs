// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.RoomMessage
{
    // 玩家列表类型
    // 大厅玩家列表
    // 大厅好友列表
    // 大厅军团列表
    // 房间邀请玩家列表
    // 快捷添加玩家列表
    // 师徒广场师傅列表
    // 师徒广场徒弟列表
    // MSGTYPE_DECLARE(MSG_NOTIFY_PLAYER_LIST),
    // 通知客户端，玩家列表
    public sealed class NotifyPlayerList : IProtocol
    {
        public const short MsgType = MessageType.MSG_NOTIFY_PLAYER_LIST;
        public short GetMsgType { get { return MsgType; } }
        public byte listType;// 玩家列表类型 enum PLAYER_LIST_TYPE
        public byte pageNumber;// 数据页编号
        public PLAYER_BRIEF[] playerList;// 本页数据
        
        public static void Send(byte listType, byte pageNumber, PLAYER_BRIEF[] playerList, object className)
        {
            var packet = new NotifyPlayerList
            {
                listType = listType,
                pageNumber = pageNumber,
                playerList = playerList
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
            listType = reader.ReadByte();
            pageNumber = reader.ReadByte();
            var length3 = reader.ReadUInt16();
            playerList = new PLAYER_BRIEF[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                playerList[i3] = new PLAYER_BRIEF();
                playerList[i3].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(listType);
            writer.Write(pageNumber);
            ushort count3 = (ushort)(playerList == null ? 0 : playerList.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                playerList[i3].WriteToStream(writer);
            }
        }
    }
}
