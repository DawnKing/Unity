using System.Collections.Generic;

public abstract class BaseProcess
{
    public static readonly BattleEvent BattleEvent = BattleEvent.Inst;

    private readonly BattleEventType _event;

    protected BaseProcess(BattleEventType evt)
    {
        _event = evt;
    }

    public virtual bool IsProcess()
    {
        return BattleEvent.HasEvent(_event);
    }

    public object GetParam()
    {
        return BattleEvent.GetParam(_event);
    }

    public List<object> GetList()
    {
        return BattleEvent.GetParam(_event) as List<object>;
    }

    public List<ulong> GetIdList()
    {
        return BattleEvent.GetParam(_event) as List<ulong>;
    }

    public virtual void Complete()
    {
        BattleEvent.RemoveEvent(_event);
    }

    public abstract void Process();
}