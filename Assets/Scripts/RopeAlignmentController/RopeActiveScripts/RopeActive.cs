using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeActive : IRopeActiveable
{
    private ObjectPool _objectPool;
    private Transform _activePos;
    private float _activeDelay;
    private List<Transform> _ropeList = new List<Transform>();
    public void SetRopeActiveController(ObjectPool objectPool, Transform activePos, float activeDelay, List<Transform> ropeList)
    {
        _objectPool = objectPool;
        _activePos = activePos;
        _activeDelay = activeDelay;
        _ropeList = ropeList;

        if (ropeList.Count <= 3)
        {
            GameObject poolObj = _objectPool.ActivePoolObject(ObjectTag.Rope, _activePos);
            poolObj.transform.position = _activePos.position;
            _ropeList.Add(poolObj.transform);
        }
    }
}
