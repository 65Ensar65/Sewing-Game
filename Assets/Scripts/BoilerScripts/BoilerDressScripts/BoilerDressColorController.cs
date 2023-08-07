using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerDressColorController : Base
{
    public float colorSpeed;
    private Material dressMaterial;
    public Color targetMaterial;
    public Transform BoilerParent;
    public float DressColorSpeed;
    public FilledImageController FilledObj;
    public GameObject Boiler;
    public ObjectType DressType;
    public WishListScriptible WishListScriptible;
    void Start()
    {
        dressMaterial = GetComponent<MeshRenderer>().material;
        //GetDressColorFinish();
    }

    private void Update()
    {
        GetReturnMaterial();
    }

    public void GetReturnMaterial()
    {
        dressMaterial.color = Color.Lerp(dressMaterial.color, targetMaterial, colorSpeed * Time.deltaTime);
    }

    public void GetDressPassiveController()
    {
        transform.DOLocalMoveY(.4f, 1.5f);
        e_animator.enabled = false;
        e_collider.enabled = true;
        transform.GetChild(3).gameObject.SetActive(true);
    }

    public void GetDressColorFinish()
    {
        if (BoilerParent.GetChild(0).GetComponent<DressColorControl>().DressType == ObjectType.Sock)
        {
            DressColorSpeed = 10f;
            Invoke(nameof(GetDressPassiveController), DressColorSpeed);
        }

        else if (BoilerParent.GetChild(0).GetComponent<DressColorControl>().DressType == ObjectType.Bra)
        {
            DressColorSpeed = 15f;
            Invoke(nameof(GetDressPassiveController), DressColorSpeed);
        }
    }

    public void GetDressReturnController(Transform _hit)
    {
        GetListController(_hit);
        _hit.transform.DOMoveY(0.178462f, .1f);
        _hit.transform.GetComponent<BoxCollider>().enabled = false;
        _hit.transform.GetComponent<Animator>().enabled = true;
        _hit.transform.GetComponent<MeshRenderer>().material.color = Color.white;
        if (DressType == ObjectType.RedBra || DressType == ObjectType.GreenBra || DressType == ObjectType.YellowBra || DressType == ObjectType.OrangeBra)
        {
            FilledObj.FillDuration = 19;
        }
        
        FilledObj.StartFilling();
        FilledObj.gameObject.SetActive(false);
        Boiler.GetComponent<Collider>().enabled = true;
        BoilerParent.GetChild(0).GetChild(0).transform.parent = e_objectPool.transform;
        transform.GetChild(3).gameObject.SetActive(false);
    }

    public void GetListController(Transform _hit)
    {
        for (int i = 0; i < WishListScriptible.WishList.Count; i++)
        {
            if (DressType == WishListScriptible.WishList[i].GetComponent<WishListController>().WishListType)
            {
                WishListScriptible.WishList[i].gameObject.SetActive(false);
                _hit.transform.gameObject.SetActive(false);
                _hit.transform.DOMove(WishListScriptible.WishList[i].transform.position, 1f);
                WishListScriptible.WishList.Remove(WishListScriptible.WishList[i]);
                GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.MoneyParticle, transform);
                obj.transform.position = transform.position;
                GameManager.Instance.AddWishListMoney();
            }

            else
            {
                _hit.transform.gameObject.SetActive(false);
                _hit.transform.DOMove(WishListScriptible.WishList[i].transform.position, 1f);
                GameObject obj = e_objectPool.ActivePoolObject(ObjectTag.MoneyParticle, transform);
                obj.transform.position = transform.position;
                GameManager.Instance.AddMoney();
            }
        }
    }
}
