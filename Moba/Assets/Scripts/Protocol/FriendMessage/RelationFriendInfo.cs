// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.FriendMessage
{
    // ----------------------------------------------------------------------
    ///    @file            protocol/FriendMessage.h
    ///    @brief
    ///    @author          yuhaixiao
    ///    @copyright       Sixcube Information Technology Co,. Ltd. (2012)
    ///    @date
    // ----------------------------------------------------------------------
    /// 人数限制
    // 好友最大人数
    // 黑名单最大人数
    /// 关系类型
    // 好友
    // 黑名单
    // Facebook好友
    /// 好友信息
    public sealed class RelationFriendInfo
    {
        public string friendUuid;
        public uint friendFlag;
        public void ReadFromStream(BinaryReader reader)
        {
            friendUuid = reader.ReadString();
            friendFlag = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(friendUuid);
            writer.Write(friendFlag);
        }
    }
}