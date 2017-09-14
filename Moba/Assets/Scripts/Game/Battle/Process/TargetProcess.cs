using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TargetProcess : BaseProcess
{
    private ISelectObjectStrategy _strategy = new SelectCloset();

    public TargetProcess() : base(BattleEventType.SelectTarget)
    {
    }

    public override bool IsProcess()
    {
        if (BattleModel.Self == null)
            return false;
        return base.IsProcess();
    }

    public override void Process()
    {
        BattleModel.Target = _strategy.GetObject(BattleModel.Self, TargetType.Enemy);
    }
}

enum TargetType
{
    Enemy,
    Team,
    All
}

internal interface ISelectObjectStrategy
{
    Entity GetObject(Entity self, TargetType targetType);
}

class SelectCloset : ISelectObjectStrategy
{
    public Entity GetObject(Entity self, TargetType targetType)
    {
        List<Entity> entities = EntityModel.GetEntities(self, typeof(Player));
        var closest = entities.FirstOrDefault();
        if (closest == null)
            return null;
       
        foreach (var entity in entities)
        {
            var select = true;
            switch (targetType)
            {
                case TargetType.Enemy:
                    if (BattleTool.IsSelfCamp(entity.Id))
                        select = false;
                    break;
                case TargetType.Team:
                    if (!BattleTool.IsSelfCamp(entity.Id))
                        select = false;
                    break;
                case TargetType.All:
                    break;
            }

            if (!select)
                continue;

            if (Vector3.Distance(self.Data.Position, entity.Data.Position) <=
                Vector3.Distance(self.Data.Position, closest.Data.Position))
            {
                closest = entity;
            }
        }

        return closest;
    }
}