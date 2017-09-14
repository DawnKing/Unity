using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class PrefabPool
{
    private readonly List<GameObject> _availableInstances;
    private readonly GameObject _objectToCopy;

    private readonly int _growth;
    private static readonly GameObject Parent = new GameObject("[PrefabPool]");
    private readonly GameObject _parent;

    public int UnrecycledPrefabCount { get; private set; }

    public int AvailablePrefabCount
    {
        get { return _availableInstances.Count; }
    }

    public int AvailablePrefabCountMaximum { get; private set; }

    #region constructors

    public PrefabPool(string name, GameObject objectToCopy)
        : this(name, objectToCopy, 0)
    {
    }

    public PrefabPool(string name, GameObject objectToCopy, int initialSize)
        : this(name, objectToCopy, initialSize, 1)
    {
    }

    public PrefabPool(string name, GameObject objectToCopy, int initialSize, int growth)
        : this(name, objectToCopy, initialSize, growth, int.MaxValue)
    {
    }

    public PrefabPool(string name, GameObject objectToCopy, int initialSize, int growth, int availableItemsMaximum)
    {
        if (growth <= 0)
        {
            throw new ArgumentOutOfRangeException("growth must be greater than 0!");
        }
        if (availableItemsMaximum < 0)
        {
            throw new ArgumentOutOfRangeException("availableItemsMaximum must be at least 0!");
        }

        _parent = name == null ? Parent : new GameObject(name);
        PrefabPoolUtils.AddChild(_parent, objectToCopy);

        _objectToCopy = objectToCopy;
        _availableInstances = new List<GameObject>(initialSize);
        _growth = growth;
        AvailablePrefabCountMaximum = availableItemsMaximum;

        _availableInstances.Add(_objectToCopy);

        if (initialSize > 0)
        {
            BatchAllocatePoolItems(initialSize);
        }
    }
    #endregion

    #region abstract_members

    /*
     * Every item passes this method before it gets recycled
     */
    protected void OnHandleAllocatePrefab(GameObject prefabInstance)
    {
        prefabInstance.SetActive(false);
    }

    /*
     * Every item passes this method before it is obtained from the pool
     */
    protected void OnHandleObtainPrefab(GameObject prefabInstance)
    {
        prefabInstance.SetActive(true);
    }

    /*
     * Every item passes this method before it gets recycled
     */
    protected void OnHandleRecyclePrefab(GameObject prefabInstance)
    {
        prefabInstance.SetActive(false);
        PrefabPoolUtils.AddChild(_parent, prefabInstance);
    }

    #endregion

    public GameObject ObtainPrefabInstance()
    {
        GameObject prefabInstance;

        if (_availableInstances.Count > 0)
        {
            prefabInstance = RetrieveLastItemAndRemoveIt();
        }
        else
        {
            if (_growth == 1 || AvailablePrefabCountMaximum == 0)
            {
                prefabInstance = AllocatePoolItem();
            }
            else
            {
                BatchAllocatePoolItems(_growth);
                prefabInstance = RetrieveLastItemAndRemoveIt();
            }

            Debug.Log(GetType().FullName + "<" + prefabInstance.GetType().Name + "> was exhausted, with " + UnrecycledPrefabCount +
            " items not yet recycled.  " +
            "Allocated " + _growth + " more.");
        }

        OnHandleObtainPrefab(prefabInstance);
        UnrecycledPrefabCount++;

        return prefabInstance;
    }

    public void RecyclePrefabInstance(GameObject prefab)
    {
        if (prefab == null) { throw new ArgumentNullException("Cannot recycle null item!"); }

        OnHandleRecyclePrefab(prefab);

        if (_availableInstances.Count < AvailablePrefabCountMaximum) { _availableInstances.Add(prefab); }
        UnrecycledPrefabCount--;

        if (UnrecycledPrefabCount < 0) { Debug.Log("More items recycled than obtained"); }
    }

    private GameObject AllocatePoolItem()
    {
        var instance = Object.Instantiate(_objectToCopy, Vector3.zero, Quaternion.identity);
        OnHandleAllocatePrefab(instance);
        PrefabPoolUtils.AddChild(_parent, instance);
        return instance;
    }

    #region herlper_methods
    private void BatchAllocatePoolItems(int count)
    {
        List<GameObject> availableItems = _availableInstances;

        int allocationCount = AvailablePrefabCountMaximum - availableItems.Count;
        if (count < allocationCount)
        {
            allocationCount = count;
        }

        for (int i = allocationCount - 1; i >= 0; i--)
        {
            availableItems.Add(AllocatePoolItem());
        }
    }

    private GameObject RetrieveLastItemAndRemoveIt()
    {
        int lastElementIndex = _availableInstances.Count - 1;
        var prefab = _availableInstances[lastElementIndex];
        _availableInstances.RemoveAt(lastElementIndex);

        return prefab;
    }
    #endregion
}

public static class PrefabPoolUtils
{
    /// <summary>
    /// Changes gameObjects parent and resets transform and layer.
    /// </summary>
    /// <param name="parent">New parent</param>
    /// <param name="child">Child whose parent needs to be changed</param>
    public static void AddChild(GameObject parent, GameObject child)
    {
        if (child == null)
        {
            throw new NullReferenceException("Child GameObject must not be null");
        }

        var t = child.transform;
        t.parent = parent == null ? null : parent.transform;

        ResetTransform(t);

        if (parent != null) { child.layer = parent.layer; }
    }

    private static void ResetTransform(Transform t)
    {
        t.localPosition = Vector3.zero;
        t.localRotation = Quaternion.identity;
        t.localScale = Vector3.one;
    }
}