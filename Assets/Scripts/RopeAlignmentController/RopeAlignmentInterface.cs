using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRopeActiveable
{
    void SetRopeActiveController(ObjectPool objectPool, Transform activePos, float activeDelay, List<Transform> ropeList);
}
