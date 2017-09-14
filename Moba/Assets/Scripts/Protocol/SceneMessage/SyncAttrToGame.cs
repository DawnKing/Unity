// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

using GameProtocol.BulkDataType;
namespace GameProtocol.SceneMessage
{
    // MSGTYPE_DECLARE(MSG_SYNC_ATTR_TOGAME),
    // 同步坦克数据给gamesvr
    public sealed class SyncAttrToGame : IProtocol
    {
        public const short MsgType = MessageType.MSG_SYNC_ATTR_TOGAME;
        public short GetMsgType { get { return MsgType; } }
        public uint sceneId;// 战场id
        public CHAR_ATTR charAttr;// 玩家的属性
        public PropsInfo[] propsBar;// 所有技能信息
        
        public static void Send(uint sceneId, CHAR_ATTR charAttr, PropsInfo[] propsBar, object className)
        {
            var packet = new SyncAttrToGame
            {
                sceneId = sceneId,
                charAttr = charAttr,
                propsBar = propsBar
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
            charAttr = new CHAR_ATTR();
            charAttr.ReadFromStream(reader);
            var length3 = reader.ReadUInt16();
            propsBar = new PropsInfo[length3];
            for (var i3 = 0; i3 < length3; i3++)
            {
                propsBar[i3] = new PropsInfo();
                propsBar[i3].ReadFromStream(reader);
            }
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(sceneId);
            charAttr.WriteToStream(writer);
            ushort count3 = (ushort)(propsBar == null ? 0 : propsBar.Length);
            writer.Write(count3);
            for(var i3 = 0; i3 < count3; i3++)
            {
                propsBar[i3].WriteToStream(writer);
            }
        }
    }
}
