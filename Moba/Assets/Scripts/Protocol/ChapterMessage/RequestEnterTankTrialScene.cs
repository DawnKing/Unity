// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.ChapterMessage
{
    // MSGTYPE_DECLARE(MSG_REQUEST_ENTER_TANK_TRIAL_SCENE),
    //网关->位置 请求进入坦克试玩场景
    public sealed class RequestEnterTankTrialScene : IProtocol
    {
        public const short MsgType = MessageType.MSG_REQUEST_ENTER_TANK_TRIAL_SCENE;
        public short GetMsgType { get { return MsgType; } }
        public uint sceneId;// 要进入的地图ID
        public uint TankId;// 坦克模板ID
        
        public static void Send(uint sceneId, uint tankId, object className)
        {
            var packet = new RequestEnterTankTrialScene
            {
                sceneId = sceneId,
                TankId = tankId
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
            sceneId = reader.ReadUInt32();
            TankId = reader.ReadUInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sceneId);
            writer.Write(TankId);
        }
    }
}
