using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressAlignmentController : Base
{
    private IDressAlignmentable dressAlignmentable;

    [Title("Dress List Values")]

    public DressListScriptible DressListScriptible;
    void Start()
    {
        dressAlignmentable = new DressAlignmentScripts();
    }

    private void Update()
    {
        dressAlignmentable.SetDressAlignParameters(DressListScriptible.DressList, DressListScriptible.DressPos.transform, DressListScriptible.DressSpeed);
    }
}
