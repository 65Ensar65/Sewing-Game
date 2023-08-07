using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressColorControl : Base
{
    private IDressAlignmentable dressAlignmentable;
    private IDressMoveBoilerable dressMoveBoilerable;

    [HideInInspector] public bool IsClick = true;
    public bool isClick
    { 
        get
        {
            return IsClick;
        }
        set
        {
            IsClick = value;
            if (IsClick)
            {
                dressAlignmentable.SetDressAlignParameters(DressListScriptible.DressList, DressListScriptible.DressPos.transform, DressListScriptible.DressSpeed);
            }
        }
    }

    [Title("Dress Scriptible")]
    public DressListScriptible DressListScriptible;
    public ObjectType DressType;
    public ObjectTag DressTag;
    void Start()
    {
        dressAlignmentable = new DressAlignmentScripts();
        dressMoveBoilerable = new DressMoveScripts();
    }

    public void DressMoveController(Transform boilerPos)
    {
        DressListScriptible.DressList.Remove(transform);
        IsClick = false;
        dressMoveBoilerable.MoveBoilerController(transform, boilerPos, DressType,e_objectPool);
    }
}
