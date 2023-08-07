using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRopeAlignment
{
    void GetRopeAlignmentController();
    void SetRopeAlignmentParameters(List<Transform> ropeList, Transform ropeTransfom, float ropeSpeed, int listIndex);
}