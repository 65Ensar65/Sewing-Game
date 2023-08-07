using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreadController : Base
{
    private IThreadable threadable;
    private RaycastHit _hit;

    [Title("Thread Rope Values")]
    public Transform ThreadRope;
    public RopeAlignmentScriptible RopeAlignment;
    public DressListScriptible DressListScriptible;
    public ClickSoundController ClickSound;

    [Title("Rope Thread Colors")]
    public Material White;
    public Material Green;

    private void Start()
    {
        threadable = new ThreadScripts();
    }
    void Update()
    {
        GetClickController();
    }

    void GetClickController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                if (_hit.transform.CompareTag("Thread"))
                {
                    ThreadRope = _hit.transform;
                    threadable.SetRopeColorController(RopeAlignment.RopeList, ThreadRope, White, Green, e_objectPool, _hit);
                    ClickSound.GetSoundController();
                }
                else if (_hit.transform.CompareTag("Machine") && ThreadRope != null)
                {
                    GameObject obj = _hit.transform.GetChild(4).GetChild(1).gameObject;
                    threadable.SetRopeMoveController(RopeAlignment.RopeList, ThreadRope, _hit, e_objectPool, obj);
                    Invoke(nameof(GetMoveDelay), 1f);
                    Debug.Log(_hit.transform.gameObject.name);
                    ThreadRope = null;
                }

                else if (_hit.transform.CompareTag("Dress"))
                {
                    ThreadRope = _hit.transform;

                    if (_hit.transform.GetComponent<DressController>().enabled == true)
                    {
                        _hit.transform.GetComponent<DressController>().GetDressImageControl(_hit.transform, e_objectPool);
                        ThreadRope = null;
                    }

                    else
                    {
                        threadable.SetRopeColorController(DressListScriptible.DressList, _hit.transform, White, Green, e_objectPool, _hit);
                        ClickSound.GetSoundController();
                    }
                }

                else if (_hit.transform.CompareTag("Boiler") && ThreadRope != null)
                {
                    ThreadRope.GetComponent<DressColorControl>().DressMoveController(_hit.transform);
                    Debug.Log(_hit.transform.gameObject.name);
                    ThreadRope.GetChild(0).gameObject.SetActive(false);  
                    ThreadRope = null;
                }

                else if (_hit.transform.CompareTag("ColorDress"))
                {
                   _hit.transform.GetComponent<BoilerDressColorController>().GetDressReturnController(_hit.transform);
                   
                }
            }
        }
    }

    void GetMoveDelay()
    {
        if (_hit.transform != null && _hit.transform.GetComponent<MachineController>() != null)
        {
            _hit.transform.GetComponent<MachineController>().RopeImage.SetActive(false);
            _hit.transform.GetComponent<MachineController>().FilledImage.SetActive(true);
            _hit.transform.GetChild(4).GetChild(1).GetComponent<FilledImageController>().StartFilling();
            _hit.transform.GetComponent<MachineController>().GetMachineActiveRope();
        }
    }
}
