using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ThreadScripts : IThreadable
{
    public void SetRopeMoveController(List<Transform> threadRopelist, Transform threadRope, RaycastHit hit, ObjectPool objectPool, GameObject FilledObj)
    {
        threadRope.GetChild(0).gameObject.SetActive(false);
        threadRope.DOScaleY(1.028453f, .01f);
        threadRopelist.Remove(threadRope);
        threadRope.DOMove(hit.transform.GetChild(0).position, 1f).OnComplete(() =>
        {
            objectPool.ReturnPoolObject(ObjectTag.Rope, threadRope.gameObject);
            FilledObj.GetComponent<FilledImageController>().IsFilling = true;
            hit.transform.GetChild(6).gameObject.SetActive(true);
        });
    }

    public void SetRopeColorController(List<Transform> threadRopelist, Transform thereadRope, Material white, Material green, ObjectPool objectPool, RaycastHit hit)
    {
        for (int i = 1; i < threadRopelist.Count; i++)
        {
            threadRopelist[i].GetChild(0).GetComponent<MeshRenderer>().material.color = white.color;
        }
        thereadRope.DOScaleY(1.3f, .05f).OnComplete(() =>
        {
            thereadRope.DOScaleY(0.8536299f, .05f);
            thereadRope.GetChild(0).GetComponent<MeshRenderer>().material.color = green.color;
        });
    }
}
