using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilerController : Base
{
    public GameObject FilledObj;
    public void GetActiveFilled()
    {
        FilledObj.SetActive(true);
    }
}
