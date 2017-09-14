using System.Collections.Generic;

namespace Common.Battle.Process
{
    public abstract class BaseProcess
    {
        private readonly BattleEvent _event;
        private readonly BattleEventType _eventType;

        protected BaseProcess(BattleEventType eventType, BattleEvent battleEvent)
        {
            _eventType = eventType;
            _event = battleEvent;
        }

        public virtual bool IsProcess()
        {
            return _event.HasEvent(_event);
        }

        public object GetParam()
        {
            return _event.GetParam(_event);
        }

        public List<object> GetList()
        {
            return _event.GetParam(_event) as List<object>;
        }

        public List<ulong> GetIdList()
        {
            return _event.GetParam(_event) as List<ulong>;
        }

        public virtual void Complete()
        {
            _event.RemoveEvent(_event);
        }

        public abstract void Process();
    }
}