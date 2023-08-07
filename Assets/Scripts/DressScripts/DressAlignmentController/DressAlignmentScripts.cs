using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DressAlignmentScripts : IDressAlignmentable
{
    public void SetDressAlignParameters(List<Transform> dressList, Transform dressActivePos, float dressSpeed)
    {
        for (int i = 1; i < dressList.Count; i++)
        {
            var FirstPos = dressList[i - 1];
            var SecondPos = dressList[i];

            Vector3 targetPosition = new Vector3(FirstPos.position.x + 0.35f, SecondPos.position.y, SecondPos.position.z);
            float duration = Vector3.Distance(SecondPos.position, targetPosition) / dressSpeed;
            SecondPos.DOMove(targetPosition, duration);
        }
    }
}
