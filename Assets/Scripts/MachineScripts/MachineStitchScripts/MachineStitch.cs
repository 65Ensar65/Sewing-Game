using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class MachineStitch : IStitchable
{
    public void GetRopeActiveController(List<GameObject> MachineRope, ObjectType objectType)
    {
        for (int i = 0; i < MachineRope.Count; i++)
        {
            MachineRope[i].gameObject.SetActive(true);
        }
    }
   
    public void GetRopePassiveController(List<GameObject> machineRope, bool isTime, int index, ObjectPool objectPool, Transform sockPos, Transform machine, ObjectType machineType)
    {
        if (isTime)
        {
            if (index < machineRope.Count && machineRope[index] != null)
            {
                machineRope[index].transform.DOScale(0.5f, 0.5f).OnComplete(() =>
                {
                    if (machineRope[index] != null)
                    {
                        machineRope[index].transform.DOScale(1f, 0.1f);
                        machineRope[index].gameObject.SetActive(false);
                    }
                });
            }


            if (index == 1)
            {
                if (machineType == ObjectType.SockMachine)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Sock, sockPos);
                    obj.transform.SetParent(sockPos.transform);
                }

                else if (machineType == ObjectType.BraMachine)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Bra, sockPos);
                    obj.transform.SetParent(sockPos.transform);
                }
            }
        }
    }

    public void GetRopeFindController(MachineScriptible machineScriptible, string machineType)
    {
        machineScriptible.MachineRopeList.Clear();
        machineScriptible.Machine = GameObject.FindWithTag(machineType);

        for (int i = 0; i < machineScriptible.Machine.transform.childCount; i++)
        {
            machineScriptible.MachineRopeList.Add(machineScriptible.Machine.transform.GetChild(i).gameObject);
        }
    }

}
