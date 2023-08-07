using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : Base
{
    [HideInInspector] public IRopeAlignment ropeAlignment;

    public bool IsClick
    {
        get
        {
            return isClick;
        }
        set
        {
            isClick = value;
            if (isClick) 
            {
                ropeAlignment.GetRopeAlignmentController();
            }
        }
    }
    private bool isClick = true;

    [Title("Rope List Alignment Values")]
    public RopeAlignmentScriptible AlignmentScriptible;
    public float RopeSpeed;

    void Start()
    {
        ropeAlignment = new RopeAlignment();
        ropeAlignment.SetRopeAlignmentParameters(AlignmentScriptible.RopeList, this.transform, RopeSpeed, AlignmentScriptible.ListIndex);
    }

    void Update()
    {
        IsClick = true;
    }
}
