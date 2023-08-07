using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public interface IDressActiveable
{
    void GetDressActiveController(SkinnedMeshRenderer dressMeshRenderer, float dressScale);
}

public interface IDressBraActivable
{
    void GetDressBraActivable(SkinnedMeshRenderer braHanger, SkinnedMeshRenderer bra,  float dressScale);
}

public interface IDressImageble
{
    void GetDressImageController(Transform dressImage, Transform targetImage, Transform hitPos, ObjectPool objectPool,
                                 Image dressImg, Sprite dressSprite1, Sprite dressSprite2, ObjectType dressType);
}

public interface IDressAlignmentable
{
    void SetDressAlignParameters(List<Transform> dressList, Transform dressActivePos, float dressSpeed);
}

public interface IDressMoveBoilerable
{
    void MoveBoilerController(Transform dressPos, Transform hitPos, ObjectType dressType, ObjectPool objectPool);
}