using UnityEngine;

public class AnimationType
{
    public const string Move = "move";
    public const string Attack = "attack";
    public const string Skill1 = "skill1";
}

public class GameEntity
{
    protected Vector3 _position;
    protected Quaternion _rotate = new Quaternion();
    protected GameObject _entity;

    public uint Id { get; private set; }

    public GameEntity(uint id, Vector3 position)
    {
        Id = id;
        _position = position;
    }

    public virtual float Speed
    {
        get { return 0.1f; }
    }

    public virtual void StartMove()
    {
    }

    public virtual void EndMove()
    {
    }

    public virtual void RotateTo(float time, float radian)
    {
    }

    public virtual void MoveTo(float targetX, float targetZ)
    {
        _position.x += targetX;
        _position.z += targetZ;

        if (_entity)
        {
            _entity.transform.position = _position;
        }
    }

    public virtual GameObject Entity
    {
        get { return _entity; }
        set
        {
            _entity = value;
        }
    }

    public Vector3 Position
    {
        get { return _position; }
    }

    public Quaternion Rotate
    {
        get { return _rotate; }
    }
}

public static class EntityHelper
{
    public const string FireBone = "fire";

    public static Transform GetBoneTransform(string boneName, Transform entityTransform)
    {
        if (string.CompareOrdinal(entityTransform.name, boneName) == 0)
            return entityTransform;
        var length = entityTransform.childCount;
        for (var i = 0; i < length; i++)
        {
            var child = entityTransform.GetChild(i);
            var result = GetBoneTransform(boneName, child);
            if (result != null)
                return result;
        }
        return null;
    }

    public static GameObject GetChildGameObject(GameObject parent, string withName)
    {
        Transform[] ts = parent.transform.GetComponentsInChildren<Transform>();
        foreach (Transform t in ts)
        {
            if (t.gameObject.name.Contains(withName))
            {
                return t.gameObject;
            }
        }
        return null;
    }
}