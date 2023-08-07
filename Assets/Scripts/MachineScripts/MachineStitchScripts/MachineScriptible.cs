using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stitch", menuName = "Stitch")]
public class MachineScriptible : ScriptableObject
{
    public GameObject Machine;
    public List<GameObject> MachineRopeList = new List<GameObject>();
    public ObjectType MachineType;

    public void ClearMachineRopeList()
    {
        MachineRopeList.Clear();
    }
}

