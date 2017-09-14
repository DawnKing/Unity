using System;
using System.Collections.Generic;
using UnityEngine;

public static class EntityModel
{
    // 缓存
    private static readonly List<Entity> EntityPool = new List<Entity>();
    private static readonly List<SkillEntity> SkillEntityPool = new List<SkillEntity>();
    private static readonly ObjectPool<MoveList> MoveListPool = new ObjectPool<MoveList>(100);

    // 数据
    private static readonly Dictionary<ulong, Entity> Entities = new Dictionary<ulong, Entity>();
    private static readonly Dictionary<ulong, MoveList> Moves = new Dictionary<ulong, MoveList>();

    public static Dictionary<ulong, Entity> GetEntities() { return Entities;  }
    public static Dictionary<ulong, MoveList> GetMoves() {  return Moves;  }

    public static void AddEntity(Entity entity)
    {
        if (Entities.ContainsKey(entity.Id))
            Debug.LogWarning("已经包含实体数据" + entity.Id);
        Entities[entity.Id] = entity;
    }

    public static void RemoveEntity(ulong id)
    {
        RemoveMove(id);

        if (!ContainersEntity(id))
        {
            Debug.LogWarning("!ContainersEntity" + id);
            return;
        }

        var entity = Entities[id];
        entity.Clear();
        Entities.Remove(id);

        PushEntiy(entity);
    }

    public static bool ContainersEntity(ulong id)
    {
        return Entities.ContainsKey(id);
    }

    public static Entity GetEntity(ulong id)
    {
        if (!ContainersEntity(id))
            return null;
        return Entities[id];
    }

    public static MovableEntity GetMovable(ulong id)
    {
        if (!ContainersEntity(id))
            return null;
        return Entities[id] as MovableEntity;
    }

    public static Fighter GetFighter(ulong id)
    {
        if (!ContainersEntity(id))
            return null;
        return Entities[id] as Fighter;
    }

    public static Player GetPlayer(ulong id)
    {
        if (!ContainersEntity(id))
            return null;
        return Entities[id] as Player;
    }

    public static List<Entity> GetEntities(Entity self, Type type)
    {
        List<Entity> result = new List<Entity>();
        foreach (var pair in Entities)
        {
            var entity = pair.Value;
            if (entity == self)
                continue;
            if (entity != null && entity.GetType() == type)
                result.Add(entity);
        }
        return result;
    }

    public static void AddMove(ulong id, float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        MoveList list = GetMoveList(id);
        list.AddMove(fromX, fromZ, toX, toZ, direction, speed);
    }

    private static MoveList GetMoveList(ulong id)
    {
        MoveList list;
        if (IsMoving(id))
        {
            list = GetMove(id);
        }
        else
        {
            list = MoveListPool.Pop();
            Moves[id] = list;
            list.Id = id;
        }
        return list;
    }

    public static void AddMoveList(ulong id, float fromX, float fromZ, float toX, float toZ, float direction, float speed)
    {
        MoveList list = GetMoveList(id);
        list.AddMoveList(fromX, fromZ, toX, toZ, direction, speed);
    }

    public static void RemoveMove(ulong id)
    {
        var list = GetMove(id);
        if (list == null)
            return;

        list.Clear();
        MoveListPool.Push(list);

        Moves.Remove(id);
    }

    public static MoveList GetMove(ulong id)
    {
        if (!Moves.ContainsKey(id))
            return null;
        return Moves[id];
    }

    public static bool IsMoving(ulong id)
    {
        return Moves.ContainsKey(id);
    }

    private static void PushEntiy(Entity entity)
    {
        var skillEntity = entity as SkillEntity;
        if (skillEntity != null)
            SkillEntityPool.Add(skillEntity);
        else
            EntityPool.Add(entity);
    }

    public static Entity PopEntity(Type type)
    {
        foreach (var entity in EntityPool)
        {
            if (entity.GetType() == type)
            {
                EntityPool.Remove(entity);
                return entity;
            }
        }
        return null;
    }

    public static Entity PopSkillEntity(Type type)
    {
        foreach (var entity in SkillEntityPool)
        {
            if (entity.GetType() == type)
            {
                SkillEntityPool.Remove(entity);
                return entity;
            }
        }
        return null;
    }

    public static int EntityPoolCount { get { return EntityPool.Count; } }
    public static int SkillEntityPoolCount { get { return SkillEntityPool.Count; } }
    public static int MoveListPoolCount {get { return MoveListPool.Count; } }
}
