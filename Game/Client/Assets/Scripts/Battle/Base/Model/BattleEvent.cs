using System;
using System.Collections.Generic;
using System.Diagnostics;
using GameProtocol;

public enum BattleEventType
{
    SelectTarget,
    MoveJoystick,
    AttachJoystick,
    Skill1,
    CreateEntity
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
            case BattleEventType.CreateEntity:
                List<object> list;
                if (_events.ContainsKey(type))
                {
                    list = _events[type] as List<object>;
                }
                else
                {
                    list = new List<object>();
                    _events[type] = list;
                }
                Debug.Assert(list != null, "list != null");
                list.Add(param);
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