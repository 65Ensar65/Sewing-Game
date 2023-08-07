using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAlignmentController : Base
{
    private IRopeActiveable ropeActivable;
    [Title("Rope Active Values")]
    public float ActiveDelay;
    public RopeAlignmentScriptible AlignmentScriptible;
    void Start()
    {
        ropeActivable = new RopeActive();
        InvokeRepeating(nameof(GetRopeActive), 2.5f, ActiveDelay);
    }

    void GetRopeActive()
    {
        ropeActivable.SetRopeActiveController(e_objectPool, transform, ActiveDelay, AlignmentScriptible.RopeList);
        AlignmentScriptible.ListIndex++;
    }
}
