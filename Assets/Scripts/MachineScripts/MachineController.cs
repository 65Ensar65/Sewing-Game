using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineController : Base
{
    [HideInInspector] public bool isFiiling;

    private IStitchable stitchable;

    [Title("Machine Image Values")]
    public GameObject RopeImage;
    public GameObject FilledImage;

    [Title("Machine Rope Active Values")]
    public MachineScriptible MachineScriptible;
    public int RopeIndex;
    public float RopePassiveTime;
    public Animator NeedleAnim;

    [Title("Machine Type Values")]
    public ObjectType MachineType;
    public string MachineName;
    void Start()
    {
        stitchable = new MachineStitch();
        stitchable.GetRopeFindController(MachineScriptible, MachineName);
        InvokeRepeating(nameof(GetMachinePassiveRope), RopePassiveTime, RopePassiveTime);
    }
    public void GetMachineActiveRope()
    {
        stitchable.GetRopeActiveController(MachineScriptible.MachineRopeList, MachineScriptible.MachineType);
    }

    public void GetMachinePassiveRope()
    {
        isFiiling = transform.GetChild(4).GetChild(1).GetComponent<FilledImageController>().IsFilling;

        if (isFiiling)
        {
            Invoke(nameof(GetPassiveDelay), .5f);
            NeedleAnim.enabled = true;
            RopeImage.SetActive(false);
            FilledImage.SetActive(true);
        }

        else
        {
            NeedleAnim.enabled = false;
            RopeIndex = 0;
            RopeImage.SetActive(true);
            FilledImage.SetActive(false);
            transform.GetChild(6).gameObject.SetActive(false);
        }
    }

    void GetPassiveDelay()
    {
        if (MachineScriptible.MachineRopeList.Count > RopeIndex && MachineScriptible.MachineRopeList[RopeIndex] != null)
        {
            stitchable.GetRopePassiveController(
                MachineScriptible.MachineRopeList,
                isFiiling,
                RopeIndex,
                e_objectPool,
                transform.GetChild(5),
                this.transform,
                MachineType
            );
            RopeIndex++;
        }
    }
}
