using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DressMoveScripts : IDressMoveBoilerable
{
    public void MoveBoilerController(Transform dressPos, Transform hitPos, ObjectType dressType, ObjectPool objectPool)
    {
        dressPos.DOMove(hitPos.GetChild(0).position, .8f).OnComplete(() =>
        {
            objectPool.ReturnPoolObject(dressPos.GetComponent<DressColorControl>().DressTag, dressPos.gameObject);
            dressPos.parent = objectPool.transform;
            dressPos.gameObject.SetActive(false);
            dressPos.parent = hitPos.GetChild(0);
            hitPos.GetChild(4).gameObject.SetActive(true);

            if (dressType == ObjectType.Sock)
            {
                hitPos.GetChild(2).gameObject.SetActive(true);
                hitPos.GetComponent<BoilerController>().GetActiveFilled();
                hitPos.GetComponent<BoilerController>().FilledObj.GetComponent<FilledImageController>().FillDuration = 10;
                hitPos.GetComponent<BoxCollider>().enabled = false;
                hitPos.GetChild(2).GetComponent<BoilerDressColorController>().GetDressColorFinish();
            }

            else if (dressType == ObjectType.Bra)
            {
                hitPos.GetChild(1).gameObject.SetActive(true);
                hitPos.GetComponent<BoilerController>().GetActiveFilled();
                hitPos.GetComponent<BoilerController>().FilledObj.GetComponent<FilledImageController>().FillDuration = 15;
                hitPos.GetComponent<BoxCollider>().enabled = false;
                hitPos.GetChild(1).GetComponent<BoilerDressColorController>().GetDressColorFinish();
            }
        });
    }
}
