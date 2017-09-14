using System.Linq;
using Assets.Scripts.Battle.Base.Control;
using UnityEngine;

public class TargetProcess : BaseProcess
{
    private readonly SelfPlayer _selfPlayer;

    private ISelectObjectStrategy _strategy = new SelectCloset();

    public TargetProcess(BattleEventType evt, SelfPlayer selfPlayer) : base(evt)
    {
        _selfPlayer = selfPlayer;
    }

    public override void Process()
    {
        BattleModel.Target = _strategy.GetObject(_selfPlayer.Entity, BattleTag.EnemyPlayer);
    }
}

internal interface ISelectObjectStrategy
{
    GameObject GetObject(GameObject self, string tag);
}

class SelectCloset : ISelectObjectStrategy
{
    public GameObject GetObject(GameObject self, string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        GameObject closestObject = objects.FirstOrDefault();
        if (closestObject == null)
            return null;

        for (int i = 1; i < objects.Length; i++)
        {
            if (Vector3.Distance(self.transform.position, objects[i].transform.position) <= 
                Vector3.Distance(self.transform.position, closestObject.transform.position))
            {
                closestObject = objects[i];
            }
        }

        return closestObject;
    }
}