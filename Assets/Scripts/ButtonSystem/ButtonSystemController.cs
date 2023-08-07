using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSystemController : Base
{
    [Title("Get Stitch Values")]
    public GameObject StitchButton;
    public GameObject StitchCamera;
    public GameObject StitchUI;

    [Title("Get Color Values")]
    public GameObject WashButton;
    public GameObject ColorCamera;
    public GameObject ColorUI;
    public void GetColorCamera()
    {
        StitchButton.SetActive(true);
        WashButton.SetActive(false);
        ColorCamera.SetActive(true);
        StitchCamera.SetActive(false);
        ColorUI.SetActive(true);
        StitchUI.SetActive(false);
    }

    public void GetStitchCamera()
    {
        StitchButton.SetActive(false);
        WashButton.SetActive(true);
        ColorCamera.SetActive(false);
        StitchCamera.SetActive(true);
        ColorUI.SetActive(false);
        StitchUI.SetActive(true);
    }
}
