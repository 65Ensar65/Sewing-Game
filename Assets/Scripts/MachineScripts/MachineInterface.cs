using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IStitchable
{
    void GetRopeActiveController(List<GameObject> machineRope, ObjectType objectType);
    void GetRopePassiveController(List<GameObject> machineRope, bool isTime, int index, ObjectPool objectPool, Transform sockPos, Transform machine, ObjectType machineType);
    void GetRopeFindController(MachineScriptible machineScriptible, string machineType);
}
