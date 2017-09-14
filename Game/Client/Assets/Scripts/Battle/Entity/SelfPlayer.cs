using UnityEngine;

public sealed class SelfPlayer : GameEntity
{
    public SelfPlayer(uint id, Vector3 position) : base(id, position)
    {
    }

    public bool IsMovable()
    {
        return true;
    }

    internal bool IsAttack()
    {
        return true;
    }
}