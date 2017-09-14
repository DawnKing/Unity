using UnityEngine;

public class EntityData
{
    public Vector3 Position { get { return _position; } }
    public Quaternion Rotation { get; private set; }

    private Vector3 _position;

    public void UpdateData(Vector3 position, Quaternion rotation)
    {
        _position = position;
        Rotation = rotation;
    }

    public void Clear()
    {
    }

    public float X { get { return _position.x; } set { _position.x = value; } }
    public float Y { get { return _position.y; } set { _position.y = value; } }
    public float Z { get { return _position.z; } set { _position.z = value; } }

    public void SetPosition(Vector3 position)
    {
        _position = position;
    }

    public void SetPosition(float x, float y, float z)
    {
        _position.Set(x, y, z);
    }

    public void SetRotation(Quaternion rotation)
    {
        Rotation = rotation;
    }

    public void SetRotation(float x, float y, float z, float w)
    {
        Rotation.Set(x, y, z, w);
    }
}

public class MovableData : EntityData
{
    public float Speed = 140 / 39.37f;
}

public class FighterData : MovableData
{
    public int Hp { get; private set; }
    public int MaxHp { get; private set; }

    public string Skill { get; private set; }
    public float SkillRadian { get; private set; }

    public void UpdateFigter(int hp, int maxHp)
    {
        Hp = hp;
        MaxHp = maxHp;
    }

    public void SetSkill(string skill, float radian)
    {
        Skill = skill;
        SkillRadian = radian;
    }

    public void UpdateData(int hp, int maxHp)
    {
        Hp = hp;
        MaxHp = maxHp;
    }
}

public class PlayerData : FighterData
{
    public void UpdateData(float x, float z, int hp, int maxHp)
    {
        UpdateData(hp, maxHp);
        X = x;
        Z = z;
    }
}

public class SelfData : PlayerData
{
}