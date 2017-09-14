using System.Collections.Generic;
using UnityEngine;

public enum BattleEventType
{
    // 实体
    UpdateHp,

    // 玩家自己
    SelectTarget,
    MoveJoystick,
    AttachJoystick,
    Skill1,

    // 玩家
    CreatePlayer,
    DeletePlayer,

    // 技能
    DeleteSkill,
}

public sealed class BattleEvent
{
    private readonly Dictionary<BattleEventType, object> _events = new Dictionary<BattleEventType,object>();

    #region Inst
    private static readonly BattleEvent Instant = new BattleEvent();
    static BattleEvent() { }
    private BattleEvent() { }
    public static BattleEvent Inst { get { return Instant; } }
    #endregion

    public void AddEvent(BattleEventType type, object param = null)
    {
        switch (type)
        {
            case BattleEventType.UpdateHp:
            case BattleEventType.CreatePlayer:
                List<object> list = _events.ContainsKey(type) ? _events[type] as List<object> : new List<object>();
                Debug.Assert(list != null, "list != null");
                list.Add(param);
                _events[type] = list;
                break;
   
            case BattleEventType.DeletePlayer:
            case BattleEventType.DeleteSkill:
                List<ulong> idList = _events.ContainsKey(type) ? _events[type] as List<ulong> : new List<ulong>();
                Debug.Assert(idList != null, "list != null");
                idList.Add((ulong)param);
                _events[type] = idList;
                break;

            default:
                _events[type] = param;
                break;
        }
    }

    internal bool HasEvent(BattleEventType type)
    {
        return _events.ContainsKey(type);
    }

    public object GetParam(BattleEventType type)
    {
        return _events[type];
    }

    internal void RemoveEvent(BattleEventType type)
    {
        _events.Remove(type);
    }
}