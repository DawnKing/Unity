// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.RoomMessage
{
    // MSGTYPE_DECLARE(MSG_GAME_REMOVE_SCENE),
    // 通知track销毁战场
    public sealed class GameRemoveScene : IProtocol
    {
        public const short MsgType = MessageType.MSG_GAME_REMOVE_SCENE;
        public short GetMsgType { get { return MsgType; } }
        public uint SceneId;// 房间id
        public uint Err;// 错误id，0表示创建成功
        
        public static void Send(uint sceneId, uint err, object className)
        {
            var packet = new GameRemoveScene
            {
                SceneId = sceneId,
                Err = err
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
            SceneId = reader.ReadUInt32();
            Err = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(SceneId);
            writer.Write(Err);
        }
    }
}
