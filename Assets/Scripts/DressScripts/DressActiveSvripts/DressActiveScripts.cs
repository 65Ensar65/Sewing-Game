using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressActiveScripts : IDressActiveable, IDressBraActivable
{
    public void GetDressActiveController(SkinnedMeshRenderer sock, float dressScale)
    {
        sock.SetBlendShapeWeight(0, dressScale);
    }

    public void GetDressBraActivable(SkinnedMeshRenderer braHanger, SkinnedMeshRenderer bra, float dressScale)
    {
        bra.SetBlendShapeWeight(0, dressScale);
        braHanger.SetBlendShapeWeight(0, dressScale);
    }
}

