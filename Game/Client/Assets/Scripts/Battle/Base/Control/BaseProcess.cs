using Assets.Scripts.Battle.Base.Model;

namespace Assets.Scripts.Battle.Base.Control
{
    public abstract class BaseProcess
    {
        private readonly BattleEvent _battleEvent;
        protected readonly BattleModel BattleModel;
        private readonly BattleEventType _event;

        protected BaseProcess(BattleEventType evt)
        {
            _event = evt;
            _battleEvent = BattleEvent.Inst;
            BattleModel = BattleModel.Inst;
        }

        public virtual bool IsProcess()
        {
            return _battleEvent.HasEvent(_event);
        }

        public object GetParam()
        {
            return _battleEvent.GetParam(_event);
        }

        public virtual void Complete()
        {
            _battleEvent.RemoveEvent(_event);
        }

        public abstract void Process();
    }
}