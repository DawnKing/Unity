using UnityEngine;

public static class EntityTool
{
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