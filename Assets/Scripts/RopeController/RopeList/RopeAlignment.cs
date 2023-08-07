using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RopeAlignment : IRopeAlignment
{
    private List<Transform> _ropelist;
    private Transform _ropeTransform;
    private float _ropeSpeed;
    private int _listIndex;
    public void GetRopeAlignmentController()
    {
        for (int i = 1; i < _ropelist.Count; i++)
        {
            var FirstPos = _ropelist[i - 1];
            var SecondPos = _ropelist[i];

            Vector3 targetPosition = new Vector3(FirstPos.position.x + 0.25f, SecondPos.position.y, SecondPos.position.z);
            float duration = Vector3.Distance(SecondPos.position, targetPosition) / _ropeSpeed;
            SecondPos.DOMove(targetPosition, duration);
        }
    }

    public void SetRopeAlignmentParameters(List<Transform> ropeList, Transform ropeTransfom, float ropeSpeed, int listIndex)
    {
        _ropelist = ropeList;
        _ropeTransform = ropeTransfom;
        _ropeSpeed = ropeSpeed;
        _listIndex = listIndex;
    }
}
