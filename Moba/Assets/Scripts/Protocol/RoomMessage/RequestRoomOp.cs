// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // 离开队伍
    // 队员准备完成
    // 队员取消准备
    // 改变阵营
    // 观战
    // 切换房间
    // 房间内成员的战队发生变化
    // 队长权限起始
    // 踢出队伍
    // 关闭位置
    // 开启位置
    // 设置密码
    // 所有队员都准备完成，队长选择进入战场
    // 更换队长
    // 更换匹配模式
    // 队长权限终止
    // 以下协议由服务端返回，客户端不能发送
    // 通知房间密码
    // 通知清除房间所有人准备状态
    // 通知客户端，玩家从战场返回房间
    // 通知客户端，所有玩家从战场返回
    // MSGTYPE_DECLARE(MSG_REQUEST_ROOM_OP),
    // 客户端请求队伍操作
    public sealed class RequestRoomOp : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_ROOM_OP;
        public short GetMsgType { get { return MsgType; } }
        public byte roomOp;// 操作类型
        public uint Target;// 目标角色
        
        public static void Send(byte roomOp, uint target, object className)
        {
            var packet = new RequestRoomOp
            {
                roomOp = roomOp,
                Target = target
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
            roomOp = reader.ReadByte();
            Target = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(roomOp);
            writer.Write(Target);
        }
    }
}
