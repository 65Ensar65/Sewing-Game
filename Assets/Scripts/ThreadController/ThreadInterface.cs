using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IThreadable
{
    void SetRopeMoveController(List<Transform> threadRopelist, Transform threadRope, RaycastHit hit, ObjectPool objectPool, GameObject FilledObj);
    void SetRopeColorController(List<Transform> threadRopelist, Transform thereadRope, Material white, Material green, ObjectPool objectPool, RaycastHit hit);
}
