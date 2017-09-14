// Generated by proto_to_csharp.py. DO NOT EDIT!
using System.IO;

namespace GameProtocol.WorldMessage
{
    ///区域触发器的类型，注意DEdit输出的类型必须与此一致
    // 目标监视触发器 enum TRIGGER_OBJ
    // PVP区域
    ///区域trigger的行为(进入/离开)
    // 进入
    // 离开
    ///触发器监视的目标类型, 只有当trigger的type为TT_TRIGGER时，监视目标对象才有意义
    // 不特定监视某种目标
    // 仅仅针对玩家
    // 仅仅针对NPC
    // 针对NPC和玩家
    public sealed class AreaData
    {
        public int iAreaId;// 编号, 在npc server使用时,此属性不能为空
        public string strScript;// 调用的脚本文件
        public int iType;// 触发器类型 enum TRIGGER_TYPE
        public int iMapId;// 地图索引
        public int iHeight;// 辅助数据，每个点使用同一个高度
        public int iObjType;// 监视目标类型 enum TRIGGER_OBJ
        public void ReadFromStream(BinaryReader reader)
        {
            iAreaId = reader.ReadInt32();
            strScript = reader.ReadString();
            iType = reader.ReadInt32();
            iMapId = reader.ReadInt32();
            iHeight = reader.ReadInt32();
            iObjType = reader.ReadInt32();
        }
        
        public void WriteToStream(BinaryWriter writer)
        {
            writer.Write(iAreaId);
            writer.Write(strScript);
            writer.Write(iType);
            writer.Write(iMapId);
            writer.Write(iHeight);
            writer.Write(iObjType);
        }
    }
}
