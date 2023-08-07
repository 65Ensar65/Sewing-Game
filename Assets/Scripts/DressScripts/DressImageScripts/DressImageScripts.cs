using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class DressImageScripts : IDressImageble
{
    public void GetDressImageController(Transform dressImage, Transform targetImage, Transform hitPos, ObjectPool objectPool, Image dressImg, 
                                        Sprite dressSprite1, Sprite dressSprite2, ObjectType dressType)
    {
        if (dressType == ObjectType.Sock)
        {
            dressImg.sprite = dressSprite1;
        }

        else if (dressType == ObjectType.Bra)
        {
            dressImg.sprite = dressSprite2;
        }

        dressImage.transform.position = Input.mousePosition;
        hitPos.GetComponent<DressController>().GetColorMovePos();
        dressImage.GetComponent<Image>().enabled = true;
        dressImage.gameObject.SetActive(true);
        dressImage.DORotate(new Vector3(0, -180, 0), .75f).OnComplete(() =>
        {
            dressImage.DOMove(targetImage.position, .75f).OnComplete(() =>
            {
                dressImage.GetComponent<Image>().enabled = false;
            });
        });
    }
}
