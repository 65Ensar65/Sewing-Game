using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DressController : Base
{
    private IDressActiveable dressActiveable;
    private IDressImageble dressImageble;
    private IDressAlignmentable dressAlignmentable;
    private IDressBraActivable dressBraActivable;

    private SkinnedMeshRenderer dressMeshRenderer;

    [Title("Dress Active Values")]
    public float DressScale;
    public float DressTime;

    [Title("Dress Image Values")]
    public GameObject DressImage;
    public GameObject DressTarget;
    public string DressTag;
    public string DressTargetTag;

    [Title("Dress Type Values")]
    public ObjectType DressType;
    public ObjectTag DressPoolTag;

    [Title("Dress List Values")]
    public DressListScriptible DressListScriptible;
    public bool IsSock;

    private void Awake()
    {
        dressMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        DressImage = GameObject.FindWithTag(DressTag);
        DressTarget = GameObject.FindWithTag(DressTargetTag);
    }
    void Start()
    {
        dressAlignmentable = new DressAlignmentScripts();
        dressImageble = new DressImageScripts();
        dressActiveable = new DressActiveScripts();
        dressBraActivable = new DressActiveScripts();
        InvokeRepeating(nameof(GetBlenshape), DressTime, DressTime);
        if (!IsSock)
        {
            transform.rotation = Quaternion.Euler(-48, 150, 0);
        }
    }

    private void Update()
    {
        if (DressScale == 0) 
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(true);
            if (IsSock)
            {
                transform.GetChild(3).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(5).gameObject.SetActive(true);
            }
            GetComponent<BoxCollider>().enabled = true;
        }
        if (IsSock)
        {
            dressActiveable.GetDressActiveController(dressMeshRenderer, DressScale);
        }

        else
        {
            dressBraActivable.GetDressBraActivable(transform.GetChild(3).GetComponent<SkinnedMeshRenderer>(), transform.GetChild(4).GetComponent<SkinnedMeshRenderer>(), DressScale);
        }
    }

    void GetBlenshape()
    {
        if (DressScale != 0)
        {
            DressScale -= 2;
        }
    }

    public void GetDressImageControl(Transform hit, ObjectPool objectPools)
    {
        ObjectType type = hit.GetComponent<DressController>().DressType;
        dressImageble.GetDressImageController(DressImage.transform, DressTarget.transform, hit, objectPools,
                                              GameManager.Instance.DressImage, GameManager.Instance.SockImage, GameManager.Instance.BraImage, type);
        if (IsSock)
        {
            transform.rotation = Quaternion.Euler(-90, 0, 0);
        }

        else if(!IsSock)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            Debug.Log("BraBra");
        }
    }

    public void GetColorMovePos()
    {
        DressListScriptible.DressList.Add(transform);
        transform.parent = null;
        transform.position = DressListScriptible.DressPos.transform.position;
        transform.GetComponent<DressColorControl>().enabled = true;
        transform.GetComponent<DressController>().enabled = false;
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        
    }
}
